using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Application.Common;

using WHS.Application.DTO.Entry.EntryDetail;
using WHS.Domain.Repositories.Code;
using WHS.Domain.Repositories.Entry;

namespace WHS.Application.CQRS.Entry.EntryDetailCQRS.Queries;

public class GetAllEntryDetailQuery: IRequest<PageResult<EntryDetailDto>>
{
    public string? SearchPharse { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SortBy { get; set; }
    public Domain.Constants.SortDirection SortDirection { get; set; }
}

public class GetAllEntryDetailQueryHandler(ILogger<GetAllEntryDetailQueryHandler> logger,
                                          IMapper mapper,
                                          IEntryDetailRepository entryDetailRepository)
                            : IRequestHandler<GetAllEntryDetailQuery, PageResult<EntryDetailDto>>
{
    public async Task<PageResult<EntryDetailDto>> Handle(GetAllEntryDetailQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all result");
        var (tempResult, totalCount) = await entryDetailRepository.GetAllMatchingAsync(request.SearchPharse,
                                request.PageSize,
                                request.PageNumber,
                                request.SortBy,
                                request.SortDirection);
        //var warehosueDto = warehouses.Select(WarehouseDto.FromEntity);
        var resultDtos = mapper.Map<IEnumerable<EntryDetailDto>>(tempResult);
        var result = new PageResult<EntryDetailDto>(resultDtos, totalCount, request.PageSize, request.PageNumber);
        return result!;
    }
}
