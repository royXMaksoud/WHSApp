using AutoMapper;
using WHS.Application.CQRS.Code.WarehouseCQRS.Commands;
using WHS.Domain.Entities.Code;

public class WarehouseProfile : Profile
{
    public WarehouseProfile()
    {
        CreateMap<UpdateWarehouseCommand, Warehouse>();

        //test case :CreateMap_ForCreateWarehouseCommandTowarehouse_MapsCorrectly
        CreateMap<CreateWarehouseCommand, Warehouse>()
        .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.WarehouseName))
        .ForMember(dest => dest.DutyStationGUID, opt => opt.MapFrom(src => src.DutyStationGUID));
        //.ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.BranchId));

        CreateMap<Warehouse, WarehouseDto>()
        //.ForMember(d => d.BranchName, opt => opt.MapFrom(src => src.Branch == null ? null : src.Branch.BranchName))
        .ForMember(d => d.WarehosueFocalPoint, opt => opt.MapFrom(src => src.WarehosueFocalPoints));
        //.ForMember(d=>d.UserName,opt=>opt.MapFrom(src=>new WarehouseFocalPoint { CreateDate=src.CreateDate });
    }
}