using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.CQRS.ShipmentRequestCQRS.Commands;
using WHS.Domain.Entities.Release;
using WHS.Domain.Entities.Shipment;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Release;
using WHS.Domain.Repositories.Shipment;
using WHS.Domin.Constants;
using WHS.Domin.Services;

namespace WHS.Application.CQRS.Release.Commands
{
    public class DeleteReleaseRequestCommand(Guid id):IRequest
    {
        public Guid Id { get; } = id;
    }
    public class DeleteReleaseRequestCommandHandler(ILogger<DeleteReleaseRequestCommandHandler> logger,
                                                    IReleaseRequestRepository repository,
                                                    IAuthorizationService<ReleaseRequest> authorizationService) : IRequestHandler<DeleteReleaseRequestCommand>
    {
        public async Task Handle(DeleteReleaseRequestCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting request with id: {request.Id}");
            var result = await repository.GetByIdAsync(request.Id);
            if (result == null)
                throw new NotFoundException(nameof(ReleaseRequest), request.Id.ToString());
            if (!authorizationService.Authorize(result, ResourceOperation.Delete))
                throw new ForbidException();
            await repository.Delete(result);
        }
    }
}
