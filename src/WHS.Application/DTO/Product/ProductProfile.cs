using AutoMapper;
using WHS.Application.CQRS.ProductCQRS.Commands;
using WHS.Application.DTO.Product;
using WHS.Domain.Entities.Code;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.InventoryItems, opt => opt.MapFrom(src => src.InventoryItems)); // Ensure InventoryItems are mapped properly
        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}