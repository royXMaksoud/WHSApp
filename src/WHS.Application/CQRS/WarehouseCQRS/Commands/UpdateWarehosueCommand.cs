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
                                    IWarehouseRepository warehosueRepository,
                                    AutoMapper.IMapper mapper,
                                    IWarehouseAuthorizationService wHSAuthorizationService) : IRequestHandler<UpdateWarehouseCommand>

{
    public async Task Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updateing warehosue with id: {request.WarehouseId}");
        var warehouse = await warehosueRepository.GetByIdAsync(request.WarehouseId);
        if (warehouse is null)
            throw new NotFoundException(nameof(Warehouse), request.WarehouseId.ToString());
        if (!wHSAuthorizationService.Authorize(warehouse, ResourceOperation.Update))
            throw new ForbidException();

        mapper.Map(request, warehouse);
        await warehosueRepository.SaveChanges();
        //return true;
    }
}