using WHS.Application.DTO.Code.CodeTableValue;

namespace WHS.Application.DTO.Code.CodeTable
{
    public class CodeTableDto
    {
        public Guid TableId { get; set; } // Primary Key
        public string TableName { get; set; } = default!;
        public string TableDescription { get; set; } = default!;
        public List<CodeTableValueDto> CodeTableValueDtos { get; set; } = [];
      

    }
}
