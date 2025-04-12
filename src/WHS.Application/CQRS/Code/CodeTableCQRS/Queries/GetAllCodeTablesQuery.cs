using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Application.Common;
using WHS.Application.DTO.Code.CodeTable;
using WHS.Domain.Repositories.Code;

namespace WHS.Application.CQRS.Code.CodeTableCQRS.Queries
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
