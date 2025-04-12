using WHS.Application.CQRS.Code.CodeTableCQRS.Queries;
using WHS.Application.DTO.Code.CodeTable;
using WHS.Application.GenericValidtor;

namespace WHS.Application.CQRS.Code.CodeTableCQRS.Validtor
{

    public class GetAllCodeTableQueryValidator : BaseQueryValidator<GetAllCodeTablesQuery>
    {
        public GetAllCodeTableQueryValidator()
            : base(new[] { 5, 10, 15, 30 },
                   new[] { nameof(CodeTableDto.TableName), nameof(CodeTableDto.TableDescription) })
        {
        }
    }


}
