using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WHS.Domain.Entities.Code;
using FluentAssertions;
using WHS.Application.CQRS.WarehouseCQRS.Commands;

namespace Tests;

public class WarehouseProfileTests
{
    private IMapper _mapper;
    public WarehouseProfileTests()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<WarehouseProfile>();
        });
        _mapper = configuration.CreateMapper();

    }
    [Fact()]
    public void CreateMap_ForWarehouseToWarehouseDto_MapsCorrectly()
    {
        //arrange
    
        var warehouse = new Warehouse()
        {
            WarehouseId= Guid.Parse("d13e32ae-8fae-4e54-b217-0003048c27db"),
            WarehouseName = "Berlin",
            DutyStationId = Guid.Parse("90266a3c-8cec-4a20-8be7-4faf991d9f5c"),
            BranchId = Guid.Parse("90266a3c-8cec-4a20-8be7-4faf991d9f5c"),
            //OwnerId="90266a3c-8cec-4a20-8be7-4faf991d9f5c",
        };
        //act
        var warehouseDto = _mapper.Map<WarehouseDto>(warehouse);

        //assert 
        warehouseDto.Should().NotBeNull();
        warehouseDto.WarehouseId.Should().Be(warehouse.WarehouseId);
        warehouseDto.WarehouseName.Should().Be(warehouse.WarehouseName);
        warehouseDto.DutyStationId.Should().Be(warehouse.DutyStationId);
        warehouseDto.BranchId.Should().Be(warehouse.BranchId);

    }

    [Fact()]
    public void CreateMap_ForCreateWarehouseCommandToWarehouse_MapsCorrectly()
    {
        //arrange
  
        var warehouse = new CreateWarehouseCommand()
        {
            WarehouseName = "Berlin",
            DutyStationId = Guid.Parse("90266a3c-8cec-4a20-8be7-4faf991d9f5c"),
            BranchId = Guid.Parse("90266a3c-8cec-4a20-8be7-4faf991d9f5c"),
            //OwnerId="90266a3c-8cec-4a20-8be7-4faf991d9f5c",
        };
        //act
        var warehouse = _mapper.Map<Warehouse>(warehouse);

        //assert 
        warehouse.Should().NotBeNull();
       
        warehouse.WarehouseName.Should().Be(warehouse.WarehouseName);
        warehouse.DutyStationId.Should().Be(warehouse.DutyStationId);
        warehouse.BranchId.Should().Be(warehouse.BranchId);

    }

    [Fact()]
    public void CreateMap_ForUpdateWarehouseCommandToWarehouse_MapsCorrectly()
    {
        //arrange

        var warehouse = new UpdateWarehouseCommand()
        {
            WarehouseId = Guid.Parse("d13e32ae-8fae-4e54-b217-0003048c27db"),
            WarehouseName = "Berlin",
      
        };
        //act
        var warehouse = _mapper.Map<Warehouse>(warehouse);

        //assert 
        warehouse.Should().NotBeNull();
        warehouse.WarehouseName.Should().Be(warehouse.WarehouseName);


    }
}