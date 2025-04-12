using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.Release;
using WHS.Domain.Entities.Shipment;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories.Shipment;
using WHS.Domin.Constants;
using WHS.Domin.Services;

namespace WHS.Application.CQRS.ShipmentRequestCQRS.Commands;

public class UpdateShipmentRequestCommand: IRequest
{
    public Guid ShipmentRequestGUID { get; set; }
    public Guid WarehouseGUID { get; set; } // Foreign Key to Warehouse
    public Guid ShipmentTypeGUID { get; set; }
    public Guid SupplierGUID { get; set; } // Foreign Key to Supplier      
    public int ShipmentNumber { get; set; }
    public DateTime ShipmentDate { get; set; }
    public string Comments { get; set; } = default!;
    public bool Active { get; set; }
    public DateOnly CreateDate { get; set; }
    public DateOnly UpdateDate { get; set; }
    public string CreatedByUserId { get; set; }
    public string UpdatedByUserId { get; set; }
    // Relationships
    public ICollection<ShipmentRequestDetail> ShipmentDetails { get; set; } = [];

}
public class UpdateShipmentRequestCommandHandler(ILogger<UpdateShipmentRequestCommandHandler> logger,
                                                 IMapper mapper,
                                                 IShipmentRequestRepository entityRepository,
                                                 IAuthorizationService<ShipmentRequest> authorizationService)
    : IRequestHandler<UpdateShipmentRequestCommand>
{
    public async Task Handle(UpdateShipmentRequestCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating entry with id: {request.ShipmentRequestGUID}");

        var result = await entityRepository.GetByIdAsync(request.ShipmentRequestGUID);
        if (result is null)
            throw new NotFoundException(nameof(ShipmentRequest), request.ShipmentRequestGUID.ToString());

        // Authorization check
        if (!authorizationService.Authorize(result, ResourceOperation.Update))
            throw new ForbidException();

        // Update and save
        mapper.Map(request, result);
        await entityRepository.SaveChanges();
    }
}

