using Microsoft.AspNetCore.Authorization;
using WHS.Application.UserAuth;
using WHS.Domain.Repositories;

namespace WHS.Infrastructure.Authorization.Requirements.Warehouse
{
    public class CreatedMultipleWarehouseRequirements(int minimumWarehouseCreated) : IAuthorizationRequirement
    {
        public int MinimumwarehousesCreated { get; } = minimumWarehouseCreated;
    }

    internal class CreatedMultipleWarehouseRequirementsHandler(IWarehouseRepository warehouseRepository,
                IUserContext userContext) : AuthorizationHandler<CreatedMultipleWarehouseRequirements>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CreatedMultipleWarehouseRequirements requirement)
        {
            var currentUser = userContext.GetCurrentUser();
            var warehouses = await warehouseRepository.GetAllAsync();
            var userwarehousesCreated = warehouses.Count(x => x.OwnerId == currentUser!.Id);
            if (userwarehousesCreated >= requirement.MinimumwarehousesCreated)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}