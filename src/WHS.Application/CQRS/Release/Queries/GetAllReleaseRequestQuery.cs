using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.Common;
using WHS.Application.CQRS.Entry.EntryDetailCQRS.Queries;
using WHS.Application.DTO.Entry.EntryDetail;
using WHS.Application.DTO.Release.ReleaseRequest;
using WHS.Domain.Repositories.Entry;
using WHS.Domain.Repositories.Release;

namespace WHS.Application.CQRS.Release.Queries
{
    public class GetAllReleaseRequestQuery: IRequest<PageResult<ReleaseRequestDto>>
    {
        public string? SearchPharse { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; }
        public Domain.Constants.SortDirection SortDirection { get; set; }
    }
    public class GetAllReleaseRequestQueryHandler(ILogger<GetAllReleaseRequestQueryHandler> logger,
                                          IMapper mapper,
                                          IReleaseRequestRepository repository) : IRequestHandler<GetAllReleaseRequestQuery, PageResult<ReleaseRequestDto>>
    {
        public async Task<PageResult<ReleaseRequestDto>> Handle(GetAllReleaseRequestQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all result");
            var (tempResult, totalCount) = await repository.GetAllMatchingAsync(request.SearchPharse,
                                    request.PageSize,
                                    request.PageNumber,
                                    request.SortBy,
                                    request.SortDirection);
            //var warehosueDto = warehouses.Select(WarehouseDto.FromEntity);
            var resultDtos = mapper.Map<IEnumerable<ReleaseRequestDto>>(tempResult);
            var result = new PageResult<ReleaseRequestDto>(resultDtos, totalCount, request.PageSize, request.PageNumber);
            return result!;
        }
    }
}
