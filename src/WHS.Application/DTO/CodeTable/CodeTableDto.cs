using WHS.Application.DTO.CodeTableValue;

namespace WHS.Application.DTO.CodeTable
{
    public class CodeTableDto
    {
        public Guid TableId { get; set; } // Primary Key
        public string TableName { get; set; } = default!;
        public string TableDescription { get; set; } = default!;
        public List<CodeTableValueDto> CodeTableValueDtos { get; set; } = [];
      

    }
}
