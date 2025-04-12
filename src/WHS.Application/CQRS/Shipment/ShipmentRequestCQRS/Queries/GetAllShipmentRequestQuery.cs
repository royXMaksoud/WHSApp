using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Application.Common;
using WHS.Application.DTO.ShipmentDTO.ShipmentRequest;
using WHS.Domain.Repositories.Shipment;

namespace WHS.Application.CQRS.Shipment.ShipmentRequest.Queries;

public class GetAllShipmentRequestQuery:IRequest<PageResult<ShipmentRequestDto>>
{
    public string? SearchPharse { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SortBy { get; set; }
    public Domain.Constants.SortDirection SortDirection { get; set; }
}
public class GetALlShipmentRequestQueryHandler(ILogger<GetALlShipmentRequestQueryHandler> logger,
                                               IMapper mapper,
                                               IShipmentRequestRepository shipmentRequestRepository
                                               ) : IRequestHandler<GetAllShipmentRequestQuery, PageResult<ShipmentRequestDto>>
{
    public async Task<PageResult<ShipmentRequestDto>> Handle(GetAllShipmentRequestQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all results");
        var (tempResult, totalCount) = await shipmentRequestRepository
                                                  .GetAllMatchingAsync(request.SearchPharse,
                                                                       request.PageSize,
                                                                       request.PageNumber,
                                                                       request.SortBy,
                                                                       request.SortDirection);
        var resultDto=mapper.Map<IEnumerable<ShipmentRequestDto>>(tempResult);
        var result=new PageResult<ShipmentRequestDto>(resultDto, totalCount,request.PageSize,request.PageNumber);
        return  result;

    }
}