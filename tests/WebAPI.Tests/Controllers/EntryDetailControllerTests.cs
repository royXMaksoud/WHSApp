using Xunit;
using WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace WebAPI.Controllers.Tests
{
    public class EntryDetailControllerTests:IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public EntryDetailControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        //[Fact()]
        //public async void GetAll_ForValidRequest_Returns200k()
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();

        //    // Act
        //    var result = await client.GetAsync("/api/EntryDetail/GetAll");

        //    // Assert
        //    result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        //}
    }
}