using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Code;
using WHS.Domin.Constants;
using WHS.Domin.Services;

namespace WHS.Application.CQRS.Code.WarehouseCQRS.Commands;

public class DeleteWarehouseCommand(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}

public class DeleteWarehouseCommandHandler(
    ILogger<DeleteWarehouseCommandHandler> logger,
    IWarehouseRepository warehouseRepository,
    IAuthorizationService<Warehouse> authorizationService) : IRequestHandler<DeleteWarehouseCommand>
{
    public async Task Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting warehouse with id: {request.Id}");

        var warehouse = await warehouseRepository.GetByIdAsync(request.Id);
        if (warehouse is null)
            throw new NotFoundException(nameof(Warehouse), request.Id.ToString());

        // Authorization check before deleting the warehouse
        if (!authorizationService.Authorize(warehouse, ResourceOperation.Delete))
            throw new ForbidException();

        await warehouseRepository.Delete(warehouse);
    }
}
