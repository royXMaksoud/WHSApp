using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Domain.Entities.Account;
using WHS.Domain.Entities.Enntry;

namespace WHS.Domain.Entities.Release
{
    public class ReleaseRequestMovement
    {

        [Key]
        public Guid ReleaseRequestMovementGUID { get; set; }  // Primary Key
        public Guid ReleaseRequestGUID { get; set; } // Foreign Key to Warehouse
        public Guid FlowStatusGUID { get; set; }       
 
        public DateOnly CreateDate { get; set; }
        public DateOnly UpdateDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }

        public bool IsLastAction { get; set; }
        public int OrderId { get; set; }
        public bool Active { get; set; }

        // Relationships
        public  ReleaseRequest ReleaseRequest { get; set; }
        public User UserCreator { get; set; } = default!;

    }
}
