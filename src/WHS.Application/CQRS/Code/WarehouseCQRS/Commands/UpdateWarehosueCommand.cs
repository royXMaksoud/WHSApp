using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Code;
using WHS.Domin.Constants;
using WHS.Domin.Services;

namespace WHS.Application.CQRS.Code.WarehouseCQRS.Commands;

public class UpdateWarehouseCommand : IRequest
{
    public Guid WarehouseGUID { get; set; } // Primary Key
    public string WarehouseName { get; set; }
}

public class UpdateWarehouseCommandHandler(ILogger<UpdateWarehouseCommandHandler> logger,
                                            IWarehouseRepository warehouseRepository,
                                            IMapper mapper,
                                            IAuthorizationService<Warehouse> authorizationService)
                                    : IRequestHandler<UpdateWarehouseCommand>
{
    public async Task Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating warehouse with id: {request.WarehouseGUID}");

        var warehouse = await warehouseRepository.GetByIdAsync(request.WarehouseGUID);
        if (warehouse is null)
            throw new NotFoundException(nameof(Warehouse), request.WarehouseGUID.ToString());

        // Authorization check
        if (!authorizationService.Authorize(warehouse, ResourceOperation.Update))
            throw new ForbidException();

        // Update and save
        mapper.Map(request, warehouse);
        await warehouseRepository.SaveChanges();
    }
}




