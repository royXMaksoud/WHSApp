using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories;
using WHS.Domin.Constants;
using WHS.Domin.Services;


namespace WHS.Application.CQRS.CodeTableCQRS.Commands
{
    public class DeleteCodeTableCommand(Guid id):IRequest
    {
        public Guid Id { get; set; } = id;
    }

    public class DeleteCodeTableCommandHandler(ILogger logger,
                                                ICodeTableRepository codeTableRepository,
                                                IWarehouseAuthorizationService wHSAuthorizationService) : IRequestHandler<DeleteCodeTableCommand>
    {
        public async Task Handle(DeleteCodeTableCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleteting codeTable with id :{request.Id}");
            var result = await codeTableRepository.GetByIdAsync(request.Id);
            if (result is null)
                throw new NotFoundException(nameof(CodeTable), request.Id.ToString());
            if (!wHSAuthorizationService.AuthorizeCodeTable(result, ResourceOperation.Delete))
                throw new ForbidException();
            await codeTableRepository.Delete(result);
            //return true;
        }
    }
}
