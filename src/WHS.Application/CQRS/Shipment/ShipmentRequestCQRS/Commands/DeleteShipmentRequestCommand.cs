using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Domain.Entities.Shipment;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Shipment;
using WHS.Domin.Constants;
using WHS.Domin.Services;

namespace WHS.Application.CQRS.ShipmentRequestCQRS.Commands

{
    public class DeleteShipmentRequestCommand(Guid id):IRequest
    {
        public Guid Id { get; } = id;
    }

    public class DeleteShipmentRequestCommandHadler(ILogger<DeleteShipmentRequestCommandHadler> logger,
                                                    IShipmentRequestRepository repository,
                                                    IAuthorizationService<ShipmentRequest> authorizationService) : IRequestHandler<DeleteShipmentRequestCommand>
    {
        public async Task Handle(DeleteShipmentRequestCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting request with id: {request.Id}");
            var result=await repository.GetByIdAsync(request.Id);
            if (result == null) 
                throw new NotFoundException(nameof(ShipmentRequest),request.Id.ToString());
            if (!authorizationService.Authorize(result, ResourceOperation.Delete))
                throw new ForbidException();
            await repository.Delete(result);   
        }
    }
}
