using AutoMapper;
using WHS.Application.CQRS.Code.CodeTableCQRS.Commands;
using WHS.Application.DTO.Code.CodeTable;
using WHS.Domain.Entities.Code;

public class CodeTableProfile : Profile
{
    public CodeTableProfile()
    {
        CreateMap<CodeTable, CodeTableDto>()
            .ForMember(d => d.CodeTableValueDtos, opt => opt.MapFrom(src => src.CodeTableValues));

        CreateMap<CreateCodeTableCommand, CodeTable>()
       .ForMember(dest => dest.TableName, opt => opt.MapFrom(src => src.TableName));

    } 

}


