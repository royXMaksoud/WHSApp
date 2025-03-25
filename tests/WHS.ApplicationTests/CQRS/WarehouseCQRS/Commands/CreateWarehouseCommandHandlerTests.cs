using Xunit;
using WHS.Application.CQRS.WarehouseCQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Castle.Core.Logging;
using AutoMapper;
using WHS.Domain.Repositories;
using Castle.Components.DictionaryAdapter.Xml;
using WHS.Domain.Entities.Code;
using WHS.Application.UserAuth;
using Microsoft.Extensions.Logging;
using FluentAssertions;

namespace WHS.Application.CQRS.WarehouseCQRS.Commands.Tests;

public class CreateWarehouseCommandHandlerTests
{
    [Fact()]
    public async void Handle_ForValidCommand_ReturnsCreatedWarehouseId()
    {
        // arrange
        var loggerMock = new Mock<ILogger<CreateWarehouseCommandHandler>>();
        var mapperMock = new Mock<IMapper>();

        var command = new CreateWarehouseCommand();
        var Warehouse = new Warehouse();

        mapperMock.Setup(m => m.Map<Warehouse>(command)).Returns(Warehouse);

        var WarehouseRepositoryMock = new Mock<IWarehouseRepository>();

        WarehouseRepositoryMock.Setup(repo => repo.Create(It.IsAny<Warehouse>()))
            .ReturnsAsync(Guid.Parse("3ca667fd-469e-4b1d-acf1-73621aba763b"));

        var userContextMock = new Mock<IUserContext>();
        var currentUser = new CurrentUser("WarehouseId", "test@test.com", [], null, null);
        userContextMock.Setup(u => u.GetCurrentUser()).Returns(currentUser);


        var commandHandler = new CreateWarehouseCommandHandler(loggerMock.Object,
            mapperMock.Object,
            WarehouseRepositoryMock.Object,
            userContextMock.Object);

        // act
        var result = await commandHandler.Handle(command, CancellationToken.None);

        // assert
        result.Should().Be(Guid.Parse("3ca667fd-469e-4b1d-acf1-73621aba763b"));
        Warehouse.OwnerId.Should().Be("WarehouseId");
        WarehouseRepositoryMock.Verify(r => r.Create(Warehouse), Times.Once);
    }
}