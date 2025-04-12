using AutoMapper;
using WHS.Application.CQRS.Entry.EntryDetailCQRS.Commands;
using WHS.Application.CQRS.ShipmentRequestCQRS.Commands;
using WHS.Application.DTO.ShipmentDTO.ShipmentRequest;
using WHS.Domain.Entities.Enntry;
using WHS.Domain.Entities.Entry;
using WHS.Domain.Entities.Shipment;

public class ShipmentRequestProfile :Profile
{
    public ShipmentRequestProfile()
    {
        /////////////////////////////////////////////////////////
        ///                Query
        /////////////////////////////////////////////////////////
        CreateMap<ShipmentRequest, ShipmentRequestDto>();


        /////////////////////////////////////////////////////////
        ///                Create
        /////////////////////////////////////////////////////////
        CreateMap<ShipmentRequestDto, ShipmentRequest>();


        CreateMap<CreateShipmentRequestCommand, ShipmentRequest>()
          .ForMember(d => d.ShipmentDetails, opt => opt.MapFrom(src =>
                src.ShipmentDetails.Select(dto => new ShipmentRequestDetail
                {
                    ShipmentRequestGUID = dto.ShipmentRequestGUID == Guid.Empty ? Guid.NewGuid() : dto.ShipmentRequestGUID,
                    ProductGUID = dto.ProductGUID,
                    CreatedByUserId = dto.CreatedByUserId,
                    CreateDate=DateOnly.FromDateTime(DateTime.Now),
                    Active = dto.Active
                }).ToList()
            ))
      .ForMember(d => d.ShipmentRequestMovements, opt => opt.MapFrom(src => new List<ShipmentRequestMovement>
        {
            new ShipmentRequestMovement
            {
                ShipmentRequestMovementGUID = Guid.NewGuid(),  // Generate a new GUID
                
                FlowStatusGUID = Guid.Parse("323243243223432432"), // Set the required fixed value
                CreatedByUserId = src.CreatedByUserId, // Set the user ID who created the record
                CreateDate = DateOnly.FromDateTime(DateTime.Now), // Set the current date
                IsLastAction = true,  // Set this value to "true", can be modified as needed
                OrderId = 1, // Set the order number to 1, can be modified based on logic
                Active = true // Set the record as active
            }
        }));

        /////////////////////////////////////////////////////////
        ///                Update
        /////////////////////////////////////////////////////////

    }

}








/////////////////////////////////////////////////////////
///                Query
/////////////////////////////////////////////////////////
///


/////////////////////////////////////////////////////////
///                Create
/////////////////////////////////////////////////////////
///

/////////////////////////////////////////////////////////
///                Update
/////////////////////////////////////////////////////////