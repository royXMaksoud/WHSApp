using AutoMapper;
using WHS.Domain.Entities.Code;

public class WarehosueUserProfile : Profile
{
    public WarehosueUserProfile()
    {
        CreateMap<WarehosueUser, WarehosueUserDto>();
    }
}