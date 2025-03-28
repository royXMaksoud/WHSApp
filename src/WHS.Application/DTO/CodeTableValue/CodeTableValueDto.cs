using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Application.DTO.CodeTableValue
{
    public class CodeTableValueDto
    {
        public Guid TableValueId { get; set; } // Primary Key
        public required string ValueName { get; set; }
        public Guid TableId { get; set; } // Foreign Key to Organization
    }
}
