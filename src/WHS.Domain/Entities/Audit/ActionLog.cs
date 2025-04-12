using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.Audit
{
    public class ActionLog
    {
        [Key]
        public int Id { get; set; }
        public string ActionName { get; set; } = default!;
        public double ElapsedSeconds { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
