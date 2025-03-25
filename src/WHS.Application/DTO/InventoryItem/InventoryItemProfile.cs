using AutoMapper;
using WHS.Application.CQRS.InventoryItemCQRS.Commands;
using WHS.Domain.Entities.WHS;

public class InventoryItemProfile : Profile
{
    public InventoryItemProfile()
    {
        // Mapping CreateInventoryItemCommand to InventoryItem entity
        CreateMap<CreateInventoryItemCommand, InventoryItem>();

        // Mapping InventoryItem entity to InventoryItemDto (Ensure it's the class, not the namespace)
        CreateMap<InventoryItem, InventoryItemDto>(); // Fully qualify the class name
    }
}