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
using WHS.Application.CQRS.WarehouseCQRS.Queries;
using WHS.Application.DTO.CodeTable;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.CodeTableCQRS.Queries
{
    public class GetAllCodeTablesQuery : IRequest<PageResult<CodeTableDto>>
    {
        public string? SearchPharse { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; }
        public Domain.Constants.SortDirection SortDirection { get; set; }
    }

    public class GetAllCodeTablesQueryHandler(ILogger<GetAllCodeTablesQueryHandler> logger,
                                                      IMapper mapper,
                                                      ICodeTableRepository codeTableRepository) 
                                                         : IRequestHandler<GetAllCodeTablesQuery, PageResult<CodeTableDto>>
    {
       
        public async Task<PageResult<CodeTableDto>> Handle(GetAllCodeTablesQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all code tables");
            var (entities, totalCount) = await codeTableRepository.GetAllMatchingAsync(request.SearchPharse,
                             request.PageSize,
                             request.PageNumber,
                             request.SortBy,
                             request.SortDirection);

            var resultDto = mapper.Map<IEnumerable<CodeTableDto>>(entities);
            var result = new PageResult<CodeTableDto>(resultDto, totalCount, request.PageSize, request.PageNumber);
            return result!;
        }
    }


}
