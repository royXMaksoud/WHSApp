
using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using Moq;
using WHS.Application.UserAuth;
using WHS.Domain.Entities.Code;
using WHS.Domain.Repositories;
using WHS.Infrastructure.Authorization.Requirements.Warehouse;
using Xunit;

namespace WHS.Infrastructure.Authorization.RequirementsWarehosue.Tests
{
    public class CreatedMultipleWarehouseRequirementsHandlerTests
    {
        [Fact()]
        public async Task HandleRequirementAsync_UserHasCreatedMultipleWarehouses_ShouldSucceed()
        {
            //arrange 
            var currentUser = new CurrentUser("e0911b06-1391-4b88-9b03-62a54b2ffc7e", "user@test.com", [], null, null);
            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(m=>m.GetCurrentUser()).Returns(currentUser);
            var warehouse = new List<Warehouse>()
            {
                new()
                {
                    OwnerId=currentUser.Id
                },
                new()
                {
                    OwnerId=currentUser.Id
                },
                new()
                {
                    OwnerId="e0911b06-1391-4b88-9b03-62a54b2ffc7e"
                }

            };
            var warehouseRepositoryMock=new Mock<IWarehouseRepository>();
            warehouseRepositoryMock.Setup(r=>r.GetAllAsync()).ReturnsAsync(warehouse);
            var requirement = new CreatedMultipleWarehouseRequirements(2);
            var handler = new CreatedMultipleWarehouseRequirementsHandler(warehouseRepositoryMock.Object,userContextMock.Object);
            var context = new AuthorizationHandlerContext([requirement], null, null);

            //act 
            await handler.HandleAsync(context);
            //assert
            context.HasSucceeded.Should().BeTrue(); 
            context.HasFailed.Should().BeFalse();
          


        }

        [Fact()]
        public async Task HandleRequirementAsync_UserHasCreatedMultipleWarehouses_ShouldFail()
        {
            //arrange 
            var currentUser = new CurrentUser("e0911b06-1391-4b88-9b03-62a54b2ffc7e", "user@test.com", [], null, null);
            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(m => m.GetCurrentUser()).Returns(currentUser);
            var warehouse = new List<Warehouse>()
            {
                new()
                {
                    OwnerId=currentUser.Id
                },
               
                

            };
            var warehouseRepositoryMock = new Mock<IWarehouseRepository>();
            warehouseRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(warehouse);
            var requirement = new CreatedMultipleWarehouseRequirements(2);
            var handler = new CreatedMultipleWarehouseRequirementsHandler(warehouseRepositoryMock.Object, userContextMock.Object);
            var context = new AuthorizationHandlerContext([requirement], null, null);

            //act 
            await handler.HandleAsync(context);
            //assert
            context.HasSucceeded.Should().BeFalse();
            context.HasFailed.Should().BeTrue();



        }
    }
}