using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.Code
{
    public class CodeTableValue
    {
        [Key]
        public Guid TableValueId { get; set; } // Primary Key
        public required string ValueName { get; set; }
        public Guid TableId { get; set; } // Foreign Key to Organization

        public bool Active { get; set; }

        // Navigation Properties
        public CodeTable? CodeTable { get; set; } = default!;


    }
}
