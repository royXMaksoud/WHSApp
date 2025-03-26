using Xunit;
using WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization.Policy;
using WebAPI.Tests;
using Moq;
using WHS.Domain.Repositories;
using WHS.Infrastructure.Seeders;
using WHS.Domain.Entities.Code;
using System.Net.Http.Json;

namespace WebAPI.Controllers.Tests
{
    public class warehouseControllerTests :IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Mock<IWarehouseRepository> _warehouseRepositoryMock = new();
        private readonly Mock<IWHSSeeder> _warehouseSeederMock = new();
        public warehouseControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<IPolicyEvaluator,FakePolicyEvaluator>();

                });
            });
        }
        [Fact()]
        public async Task GetAllTest_ForValidRequest_Returns200K()
        {
            //arrange
            var client = _factory.CreateClient();

            //act
           var result= await client.GetAsync("api/Warehouse/GetAll?pageNumber=1&pageSize=10");

            //assert
            result.StatusCode.Should().BeOneOf(System.Net.HttpStatusCode.OK);

        }
        [Fact()]
        public async Task GetAllTest_ForInValidRequest_Returns400K()
        {
            //arrange
            var client = _factory.CreateClient();

            //act
            var result = await client.GetAsync("api/Warehouse/GetAll");

            //assert
            result.StatusCode.Should().BeOneOf(System.Net.HttpStatusCode.BadRequest);

        }
        [Fact]
        public async Task GetById_ForNonExistingId_ShouldReturn404NotFount()
        {
            //arrange
            var id = Guid.Parse("90266a3c-8cec-4a20-8be7-4faf991d9f5c");
            //this used to not care by if warehouse exists or not just we need to test the function 
            _warehouseRepositoryMock.Setup(m => m.GetByIdAsync(id)).ReturnsAsync((Warehouse?)null);
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync($"/api/warehouse/{id}");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);


        }
        [Fact]
        public async Task GetById_ForExistingId_ShouldReturn200OK()
        {
            //arrange
            var id = Guid.Parse("d13e32ae-8fae-4e54-b217-0003048c27db");
            var warehouse = new Warehouse()
            {
                WarehouseId = id,
                WarehouseName="Berlin"
            };
            
            _warehouseRepositoryMock.Setup(m => m.GetByIdAsync(id)).ReturnsAsync(warehouse);
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync($"/api/warehouse/{id}");
            var WarehouseDto = await response.Content.ReadFromJsonAsync<WarehouseDto>();

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            WarehouseDto.Should().NotBeNull();
            warehouse.WarehouseName.Should().Be("Berlin");
            


        }
    }
}