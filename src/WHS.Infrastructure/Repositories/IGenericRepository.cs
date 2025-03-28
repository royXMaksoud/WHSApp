using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.Common.Queries;
using WHS.Application.Interfaces;
using WHS.Domain.Entities;

namespace WHS.Infrastructure.Repositories;

internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly WarehouseDbContext _context;

    public GenericRepository(WarehouseDbContext context)
    {
        _context = context;
    }
   

    public async Task<List<T>> GetFilteredAsync(DynamicQuery query, CancellationToken cancellationToken)
    {
        IQueryable<T> entities = _context.Set<T>();

        ParameterExpression parameter = Expression.Parameter(typeof(T), "x");

        Expression finalExpression = null;

        foreach (var filter in query.Filters)
        {
            var property = typeof(T).GetProperty(filter.PropertyName);
            if (property == null) continue;

            Expression left = Expression.Property(parameter, property);
            Expression right = Expression.Constant(Convert.ChangeType(filter.Value, property.PropertyType));

            Expression comparison = filter.Operator switch
            {
                "==" => Expression.Equal(left, right),
                "!=" => Expression.NotEqual(left, right),
                ">" => Expression.GreaterThan(left, right),
                "<" => Expression.LessThan(left, right),
                "Contains" => Expression.Call(left, "Contains", null, right),
                _ => null
            };

            if (comparison == null) continue;

            finalExpression = finalExpression == null ? comparison : Expression.AndAlso(finalExpression, comparison);
        }

        if (finalExpression != null)
        {
            var lambda = Expression.Lambda<Func<T, bool>>(finalExpression, parameter);
            entities = entities.Where(lambda);
        }

        if (!string.IsNullOrEmpty(query.OrderBy))
        {
            var property = typeof(T).GetProperty(query.OrderBy);
            if (property != null)
            {
                var keySelector = Expression.Lambda(Expression.Property(parameter, property), parameter);
                string methodName = query.IsDescending ? "OrderByDescending" : "OrderBy";
                var orderByMethod = typeof(Queryable).GetMethods()
                    .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), property.PropertyType);

                entities = (IQueryable<T>)orderByMethod.Invoke(null, new object[] { entities, keySelector });
            }
        }

        return await entities.ToListAsync(cancellationToken);
    }
}

