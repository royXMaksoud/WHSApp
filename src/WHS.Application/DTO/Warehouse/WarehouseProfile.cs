using AutoMapper;
using WHS.Application.CQRS.WarehouseCQRS.Commands;
using WHS.Domain.Entities.Code;

public class WarehouseProfile : Profile
{
    public WarehouseProfile()
    {
        CreateMap<UpdateWarehouseCommand, Warehouse>();

        //test case :CreateMap_ForCreateWarehouseCommandTowarehouse_MapsCorrectly
        CreateMap<CreateWarehouseCommand, Warehouse>()
        .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.WarehouseName))
        .ForMember(dest => dest.DutyStationId, opt => opt.MapFrom(src => src.DutyStationId))
        .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.BranchId));

        CreateMap<Warehouse, WarehouseDto>()
        .ForMember(d => d.BranchName, opt => opt.MapFrom(src => src.Branch == null ? null : src.Branch.BranchName))
        .ForMember(d => d.warehouseUsers, opt => opt.MapFrom(src => src.warehouseUsers));
        //.ForMember(d=>d.UserName,opt=>opt.MapFrom(src=>new WarehouseFocalPoint { CreateDate=src.CreateDate });
    }
}