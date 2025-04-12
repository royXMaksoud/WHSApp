using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Code.CodeTable;

namespace WHS.Application.DTO.Code.CodeTableValue
{
    public class CodeTableValueDto
    {
        public Guid TableValueId { get; set; } // Primary Key

        public string ValueName { get; set; } = default !;
        public  string TableName { get; set; } = default!;
        public Guid TableId { get; set; } // Foreign Key to code tables
        public CodeTableDto CodeTableDto { get; set; }
    }
}
