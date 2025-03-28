using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories;
using WHS.Domin.Constants;
using WHS.Domin.Services;

namespace WHS.Application.CQRS.WarehouseCQRS.Commands;

public class UpdateWarehouseCommand : IRequest
{
    public Guid WarehouseId { get; set; } // Primary Key
    public string WarehouseName { get; set; }
}

public class UpdateWarehouseCommandHandler(ILogger<UpdateWarehouseCommandHandler> logger,
                                    IWarehouseRepository warehouseRepository,
                                    IMapper mapper,
                                    IWarehouseAuthorizationService warehouseAuthorizationService) : IRequestHandler<UpdateWarehouseCommand>

{
    public async Task Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updateing warehouse with id: {request.WarehouseId}");
        var warehouse = await warehouseRepository.GetByIdAsync(request.WarehouseId);
        if (warehouse is null)
            throw new NotFoundException(nameof(Warehouse), request.WarehouseId.ToString());
        if (!warehouseAuthorizationService.Authorize(warehouse, ResourceOperation.Update))
            throw new ForbidException();

        mapper.Map(request, warehouse);
        await warehouseRepository.SaveChanges();
        //return true;
    }
}