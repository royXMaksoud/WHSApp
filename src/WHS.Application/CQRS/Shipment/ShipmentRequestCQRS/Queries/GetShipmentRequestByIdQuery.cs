using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.CQRS.Code.WarehouseCQRS.Queries;
using WHS.Application.DTO.ShipmentDTO.ShipmentRequest;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Code;
using WHS.Domain.Repositories.Shipment;

namespace WHS.Application.CQRS.Shipment.ShipmentRequestCQRS.Queries;

public class GetShipmentRequestByIdQuery(Guid id) : IRequest<ShipmentRequestDto>
{
    public Guid Id { get; } = id;
}


public class GetShipmentRequestByIdQueryHandler(ILogger<GetShipmentRequestByIdQueryHandler> logger
                                     , IMapper mapper
                                     , IShipmentRequestRepository repository) : IRequestHandler<GetShipmentRequestByIdQuery, ShipmentRequestDto>
{
    public async Task<ShipmentRequestDto> Handle(GetShipmentRequestByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting Shipment{request.Id}");
        var tempResult = await repository.GetByIdAsync(request.Id);
        if (tempResult is null)
            throw new NotFoundException(nameof(ShipmentRequest), request.Id.ToString());
        //var warehouseDto = WarehouseDto.FromEntity(warehouse);
        var result = mapper.Map<ShipmentRequestDto?>(tempResult);
        return result;
    }
}