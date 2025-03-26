using AutoMapper;
using WHS.Domain.Entities.Code;

public class warehouseUserProfile : Profile
{
    public warehouseUserProfile()
    {
        CreateMap<warehouseUser, warehouseUserDto>();
    }
}