
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.Entry;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Entry;
using WHS.Domin.Constants;
using WHS.Domin.Services;

namespace WHS.Application.CQRS.Entry.EntryDetailCQRS.Commands
{
    public class DeleteEntryDetailCommand(Guid id) :IRequest
    {
        public Guid Id { get; } = id;
    }
    public class DeteleEntryDetailCommandHandler(ILogger<DeteleEntryDetailCommandHandler> logger,
                                                    IEntryDetailRepository entityRepository,
                                                    IAuthorizationService<EntryDetail> authorizationService) : IRequestHandler<DeleteEntryDetailCommand>
    {
        public async Task Handle(DeleteEntryDetailCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting entry with id: {request.Id}");

            var result = await entityRepository.GetByIdAsync(request.Id);
            if (result is null)
                throw new NotFoundException(nameof(EntryDetail), request.Id.ToString());

            // Authorization check before deleting the warehouse
            if (!authorizationService.Authorize(result, ResourceOperation.Delete))
                throw new ForbidException();

            await entityRepository.Delete(result);
        }
    }
}
