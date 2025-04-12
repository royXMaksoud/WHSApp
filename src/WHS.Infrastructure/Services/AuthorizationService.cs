using Microsoft.Extensions.Logging;
using WHS.Application.UserAuth;
using WHS.Domain.Constants;
using System;
using System.Linq.Expressions;
using System.Reflection;
using WHS.Domin.Constants;

namespace WHS.Domin.Services
{
    public class AuthorizationService<TEntity> : IAuthorizationService<TEntity> where TEntity : class
    {
        private readonly ILogger<AuthorizationService<TEntity>> _logger;
        private readonly IUserContext _userContext;
        private readonly Func<TEntity, string> _ownerIdFunc;

        public AuthorizationService(ILogger<AuthorizationService<TEntity>> logger,
                                    IUserContext userContext)
        {
            _logger = logger;
            _userContext = userContext;

            // Automatically find the OwnerUserId property if it exists
            var property = typeof(TEntity).GetProperty("OwnerUserId", BindingFlags.Public | BindingFlags.Instance);
            if (property == null || property.PropertyType != typeof(string))
            {
                throw new InvalidOperationException($"Entity {typeof(TEntity).Name} must have a public string property 'OwnerUserId'.");
            }

            // Compile a function to get the OwnerUserId dynamically
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var propertyAccess = Expression.Property(parameter, property);
            var lambda = Expression.Lambda<Func<TEntity, string>>(propertyAccess, parameter);
            _ownerIdFunc = lambda.Compile();
        }

        public bool Authorize(TEntity entity, ResourceOperation resourceOperation)
        {
            var user = _userContext.GetCurrentUser();
            string entityOwnerId = _ownerIdFunc(entity);

            _logger.LogInformation("Authorizing user {UserEmail}, to {Operation} for entity {EntityType}",
                user.Email, resourceOperation, typeof(TEntity).Name);

            if (resourceOperation == ResourceOperation.Read || resourceOperation == ResourceOperation.Create)
            {
                _logger.LogInformation("Create/read operation -- successful authorization");
                return true;
            }

            if (resourceOperation == ResourceOperation.Delete && user.IsInRole(UserRoles.Admin))
            {
                _logger.LogInformation(" user, delete operation - successful authorization");
                return true;
            }

            if ((resourceOperation == ResourceOperation.Delete || resourceOperation == ResourceOperation.Update)
                && user.Id == entityOwnerId)
            {
                _logger.LogInformation("Entity owner - successful authorization");
                return true;
            }

            return false;
        }
    }
}
