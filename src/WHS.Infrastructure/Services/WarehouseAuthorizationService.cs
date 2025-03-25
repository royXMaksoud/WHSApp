using Microsoft.Extensions.Logging;
using WHS.Application.UserAuth;
using WHS.Domain.Constants;
using WHS.Domain.Entities.Code;
using WHS.Domin.Constants;
using WHS.Domin.Services;

namespace WHS.Infrastructure.Services;

public class WarehouseAuthorizationService(ILogger<WarehouseAuthorizationService> logger,
                                    IUserContext userContext) : IWarehouseAuthorizationService
{
    public bool Authorize(Warehouse warehouse, ResourceOperation ResourceOperation)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("Authorizing user {UserEmail}, to {Operation} for warehouse {WarehouseName}", user.Email, ResourceOperation, warehouse.WarehouseName);
        if (ResourceOperation == ResourceOperation.Read || ResourceOperation == ResourceOperation.Create)
        {
            logger.LogInformation("Create/read operation -- successful authorization");
            return true;
        }
        if (ResourceOperation == ResourceOperation.Delete && user.IsInRole(UserRoles.Admin))
        {
            logger.LogInformation("Admin user, delete operation - successful authorization");
            return true;
        }
        if ((ResourceOperation == ResourceOperation.Delete || ResourceOperation == ResourceOperation.Update)
                      && user.Id == warehouse.OwnerId)
        {
            logger.LogInformation("Warehouse owner- successful authorization");
            return true;
        }
        return false;
    }
}