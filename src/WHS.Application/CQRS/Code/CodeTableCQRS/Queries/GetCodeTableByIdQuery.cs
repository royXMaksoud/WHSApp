using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Application.DTO.Code.CodeTable;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Code;

namespace WHS.Application.CQRS.Code.CodeTableCQRS.Queries
{
    public class GetCodeTableByIdQuery(Guid id) :IRequest<CodeTableDto>
    {
        public Guid Id { get; } = id;
    }
    public class GetCodeTableByIdQueryHandler(ILogger<GetCodeTableByIdQueryHandler> logger,
                                                      IMapper mapper,
                                                       ICodeTableRepository codeTableRepository) : IRequestHandler<GetCodeTableByIdQuery, CodeTableDto?>
    {
        public async Task<CodeTableDto?> Handle(GetCodeTableByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting Code Table by Id{request.Id}");
            var tempResult=await codeTableRepository.GetByIdAsync(request.Id);
            if (tempResult == null)
                throw new NotFoundException(nameof(CodeTable),request.Id.ToString());
            var result = mapper.Map<CodeTableDto?>(tempResult);
            return result;
        }
    }
}
