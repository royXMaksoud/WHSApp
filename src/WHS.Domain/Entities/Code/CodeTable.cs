using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Domain.Entities.Account;

namespace WHS.Domain.Entities.Code
{
    public class CodeTable
    {
        [Key]
        public Guid TableGUID { get; set; } // Primary Key
        public string TableName { get; set; } = default!;
        public string TableDescription { get; set; } = default!;
        public bool Active { get; set; }
        public User UserCreator { get; set; } = default!;
        public string CreatedByUserId { get; set; } = default!;
        // Navigation Properties
        public ICollection<CodeTableValue> CodeTableValues { get; set; } = [];
    }
}
