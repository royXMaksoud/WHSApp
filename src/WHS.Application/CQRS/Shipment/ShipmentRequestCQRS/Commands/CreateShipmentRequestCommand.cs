using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Application.DTO.Shipment.ShipmentRequestDetail;
using WHS.Application.DTO.Shipment.ShipmentRequestMovements;
using WHS.Application.UserAuth;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.Shipment;
using WHS.Domain.Repositories.Shipment;

namespace WHS.Application.CQRS.ShipmentRequestCQRS.Commands;

public class CreateShipmentRequestCommand() : IRequest<Guid>
{
   
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
    public ICollection<ShipmentRequestDetailDto> ShipmentDetails { get; set; } = [];

    public ICollection<ShipmentRequestMovemetnDto> ShipmentRequestMovements { get; set; } = [];

    // Navigation properties
    //public User UserCreator { get; set; } = default!;

    public Warehouse Warehouse { get; set; }
    public Supplier Supplier { get; set; }  // This is the navigation property
}
public class CreateShipmentRequestCommandHandler(ILogger<CreateShipmentRequestCommandHandler> logger,
                                             IMapper mapper,
                                             IShipmentRequestRepository ShipmentRequestRepository,
                                             IUserContext userContext) : IRequestHandler<CreateShipmentRequestCommand, Guid>
{
    public async Task<Guid> Handle(CreateShipmentRequestCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        logger.LogInformation("{UserEmail} {UserId} is creating a new {@Entry}", currentUser.Email, currentUser.Id, request);
        var result = mapper.Map<ShipmentRequest>(request);

        result.CreatedByUserId = currentUser.Id;
        Guid id = await ShipmentRequestRepository.Create(result);
        return id;
    }
}