using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Code;
using WHS.Domin.Constants;
using WHS.Domin.Services;

namespace WHS.Application.CQRS.Code.CodeTableCQRS.Commands
{
    public class UpdateCodeTableCommand : IRequest
    {
        public Guid TableId { get; set; }
        public string TableName { get; set; }
    }

    public class UpdateCodeTableCommandHandler(ILogger<UpdateCodeTableCommandHandler> logger,
                                               ICodeTableRepository codeTableRepository,
                                               IMapper mapper,
                                               IAuthorizationService<CodeTable> authorizationService)
        : IRequestHandler<UpdateCodeTableCommand>
    {
        public async Task Handle(UpdateCodeTableCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating code table with id: {request.TableId}");

            var result = await codeTableRepository.GetByIdAsync(request.TableId);
            if (result is null)
                throw new NotFoundException(nameof(CodeTable), request.TableId.ToString());

            // Authorization check
            if (!authorizationService.Authorize(result, ResourceOperation.Update))
                throw new ForbidException();

            // Update and save
            mapper.Map(request, result);
            await codeTableRepository.SaveChanges();
        }
    }
}
