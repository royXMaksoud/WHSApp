using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Application.Common;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.WarehouseCQRS.Queries;

public class GetAllWarehousesQuery : IRequest<PageResult<WarehouseDto>>
{
    public string? SearchPharse { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SortBy { get; set; }
    public Domain.Constants.SortDirection SortDirection { get; set; }
}

public class GetAllWarehousesQueryHandler(ILogger<GetAllWarehousesQueryHandler> logger,
                                          IMapper mapper,
                                          IWarehouseRepository warehosueRepository) : IRequestHandler<GetAllWarehousesQuery, PageResult<WarehouseDto>>
{
    public async Task<PageResult<WarehouseDto>> Handle(GetAllWarehousesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all warehoues");
        var (warehouses, totalCount) = await warehosueRepository.GetAllMatchingAsync(request.SearchPharse,
            request.PageSize,
            request.PageNumber,
            request.SortBy,
            request.SortDirection);
        //var warehosueDto = warehouses.Select(WarehouseDto.FromEntity);
        var warehosueDtos = mapper.Map<IEnumerable<WarehouseDto>>(warehouses);
        var result = new PageResult<WarehouseDto>(warehosueDtos, totalCount, request.PageSize, request.PageNumber);
        return result!;
    }
}