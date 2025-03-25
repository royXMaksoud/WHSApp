using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories;
using WHS.Domin.Constants;
using WHS.Domin.Services;
using Xunit;

namespace WHS.Application.CQRS.WarehouseCQRS.Commands.Tests;

public class UpdateWarehouseCommandHandlerTests
{
    private readonly Mock<ILogger<UpdateWarehouseCommandHandler>> _loggerMock;
    private readonly Mock<IWarehouseRepository> _WarehousesRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IWarehouseAuthorizationService> _WarehouseAuthorizationServiceMock;
    private readonly UpdateWarehouseCommandHandler _handler;
    public UpdateWarehouseCommandHandlerTests()
    {
        _loggerMock = new Mock<ILogger<UpdateWarehouseCommandHandler>>();
        _WarehousesRepositoryMock = new Mock<IWarehouseRepository>();
        _mapperMock = new Mock<IMapper>();
        _WarehouseAuthorizationServiceMock = new Mock<IWarehouseAuthorizationService>();

        _handler = new UpdateWarehouseCommandHandler(
            _loggerMock.Object,
            _WarehousesRepositoryMock.Object,
            _mapperMock.Object,
            _WarehouseAuthorizationServiceMock.Object);
    }
    [Fact()]
    public async Task Handle_WIthValidRequest_ShouldUpdateWarehouses()
    {
        //arrange
        var warehouseId = Guid.Parse("09907266-9bc0-4435-89c3-001dfe15a7d1");
        var command = new UpdateWarehouseCommand()
        {
            WarehouseId = warehouseId,
            WarehouseName = "Hamburg",

        };
        var warehouse = new Warehouse()
        {
            WarehouseId = warehouseId,
            WarehouseName = "Central Warehouse"
        };

        _WarehousesRepositoryMock.Setup(r=>r.GetByIdAsync(warehouseId)).ReturnsAsync(warehouse);
        _WarehouseAuthorizationServiceMock.Setup(m => m.Authorize(warehouse, Domin.Constants.ResourceOperation.Update)).Returns(true);

        //act
        await _handler.Handle(command,CancellationToken.None);


        //assert
        _WarehousesRepositoryMock.Verify(r=>r.SaveChanges(), Times.Once);   
        _mapperMock.Verify(c=>c.Map(command,warehouse),Times.Once);

    }
    [Fact]
    public async Task Handle_WithNonExistingWarehouse_ShouldThrowNotFoundException()
    {
        //arrange
        var warehouseId = Guid.Parse("d13e32ae-8fae-4e54-b217-0003048c27db");
        var command = new UpdateWarehouseCommand
            {
                WarehouseId = warehouseId
            };
        
        _WarehousesRepositoryMock.Setup(x=>x.GetByIdAsync(warehouseId)).ReturnsAsync((Warehouse?)null);//return null 

        //act
        Func<Task> act=async ()=>await _handler.Handle(command,CancellationToken.None);

        //assert
        await act.Should().ThrowAsync<NotFoundException>().WithMessage($"Warehouse with id {warehouseId} doesn't exist");


    }
    [Fact]
    public async Task Handle_WithNonExistingWarehouse_ShouldThrowForbidException()
    {
        //arrange
        var warehouseId = Guid.Parse("d13e32ae-8fae-4e54-b217-0003048c27db");
        var request = new UpdateWarehouseCommand
        {
            WarehouseId = warehouseId
        };
        var existingWarehouse = new Warehouse()
        {
            WarehouseId = warehouseId,
         
        };
        _WarehousesRepositoryMock.Setup(x => x.GetByIdAsync(warehouseId)).ReturnsAsync(existingWarehouse);

        _WarehouseAuthorizationServiceMock.Setup(a=>a.Authorize(existingWarehouse,ResourceOperation.Update)).Returns(false);


        //act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        //assert
        await act.Should().ThrowAsync<ForbidException>();


    }
}