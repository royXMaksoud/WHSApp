using AutoMapper;
using WHS.Application.CQRS.Entry.EntryDetailCQRS.Commands;
using WHS.Application.DTO.Entry.EntryDetail;
using WHS.Domain.Entities.Enntry;
using WHS.Domain.Entities.Entry;

public class EntryDetailProfile : Profile
{
    public EntryDetailProfile()
    {
        /////////////////////////////////////////////////////////
        ///                Query
        /////////////////////////////////////////////////////////
        CreateMap<EntryDetail, EntryDetailDto>()
        .ForMember(d => d.ShipmentNumber, opt => opt.MapFrom(src => src.ShipmentRequestDetail.ShipmentRequest.ShipmentNumber))
        .ForMember(d => d.ShipmentDate, opt => opt.MapFrom(src => src.ShipmentRequestDetail.ShipmentRequest.ShipmentDate))
        .ForMember(d => d.ProductName, opt => opt.MapFrom(src => src.ShipmentRequestDetail.Product.ProductName))
        .ForMember(d => d.USDPrice, opt => opt.MapFrom(src => src.ShipmentRequestDetail.USDPrice))
        .ForMember(d => d.EntryMovements, opt => opt.MapFrom(src => src.EntryMovements))
         .ForMember(d => d.EntryDeterminers, opt => opt.MapFrom(src => src.EntryDeterminers))
         .ForMember(d => d.ReleaseRequestDetails, opt => opt.MapFrom(src => src.ReleaseRequestDetails))
        .ForMember(d => d.EntryDetailPrices, opt => opt.MapFrom(src => src.EntryDetailPrices));
        /////////////////////////////////////////////////////////
        ///                Create
        /////////////////////////////////////////////////////////
        
        CreateMap<CreateEntryDetailCommand, EntryDetail>()
          .ForMember(d => d.EntryDeterminers, opt => opt.MapFrom(src =>
                src.EntryDeterminerDtos.Select(dto => new EntryDeterminer
                {
                    EntryDeterminerGUID = dto.EntryDeterminerGUID == Guid.Empty ? Guid.NewGuid() : dto.EntryDeterminerGUID,
                    DeterminerTypeGUID = dto.DeterminerTypeGUID,
                    DeterminerValue = dto.DeterminerValue,
                    Active = dto.Active
                }).ToList()
            ))
      .ForMember(d => d.EntryMovements, opt => opt.MapFrom(src => new List<EntryMovement>
        {
            new EntryMovement
            {
                EntryMovementGUID = Guid.NewGuid(),  // Generate a new GUID
                EntryDetailGUID = src.ShipmentRequestDetailGUID, // Set the same value as the parent
                FlowStatusGUID = Guid.Parse("323243243223432432"), // Set the required fixed value
                CreatedByUserId = src.CreatedByUserId, // Set the user ID who created the record
                CreateDate = DateOnly.FromDateTime(DateTime.Now), // Set the current date
                IsLastAction = true,  // Set this value to "true", can be modified as needed
                OrderId = 1, // Set the order number to 1, can be modified based on logic
                Active = true // Set the record as active
            }
        }));

        /////////////////////////////////////////////////////////
        ///                     Update
        /////////////////////////////////////////////////////////

        CreateMap<UpdateEntryDetailCommand, EntryDetail>()
    .ForMember(d => d.EntryDeterminers, opt => opt.MapFrom((src, dest) =>
        src.EntryDeterminerDtos.Select(dto =>
        {
            var entryDeterminer = dest.EntryDeterminers.FirstOrDefault(ed => ed.EntryDeterminerGUID == dto.EntryDeterminerGUID);
            if (entryDeterminer != null)
            {
                entryDeterminer.DeterminerValue = dto.DeterminerValue; // Update the value if it exists
                entryDeterminer.Active = dto.Active; // Update the Active status
            }
            else
            {
                // If not found, add a new EntryDeterminer
                return new EntryDeterminer
                {
                    EntryDeterminerGUID = dto.EntryDeterminerGUID == Guid.Empty ? Guid.NewGuid() : dto.EntryDeterminerGUID,
                    DeterminerTypeGUID = dto.DeterminerTypeGUID,
                    DeterminerValue = dto.DeterminerValue,
                    Active = dto.Active,
                    EntryDetail = dest
                };
            }
            return null;
        }).Where(ed => ed != null).ToList()
    ))
    .ForMember(d => d.EntryMovements, opt => opt.MapFrom((src, dest) =>
    {
        // Update EntryMovement based on any changes in EntryDetail
        var entryMovement = dest.EntryMovements.FirstOrDefault(em => em.EntryDetailGUID == src.EntryDetailGUID);
        if (entryMovement != null)
        {
            entryMovement.FlowStatusGUID = Guid.Parse("323243243223432432"); // Update FlowStatus
            entryMovement.IsLastAction = true; // Set this as true, can modify as needed
            entryMovement.Active = true; // Set it as active
            entryMovement.CreateDate = DateOnly.FromDateTime(DateTime.Now); // Set creation date to current date
            entryMovement.UpdatedByUserId = src.UpdatedByUserId; // Set the user ID who updated the record
            entryMovement.UpdateDate = src.UpdateDate;
        }
        return dest.EntryMovements; // Return the updated EntryMovements
    }));

    }
}