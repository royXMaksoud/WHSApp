using System.ComponentModel.DataAnnotations;
using WHS.Domain.Entities.Account;
using WHS.Domain.Entities.Entry;

namespace WHS.Domain.Entities.Enntry
{
    public class EntryMovement
    {
        [Key]
        public Guid EntryMovementGUID { get; set; }  // Primary Key
        public Guid EntryDetailGUID { get; set; } // Foreign Key to Warehouse
        public Guid FlowStatusGUID { get; set; }
        
     
        public DateOnly CreateDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }
        public DateOnly? UpdateDate { get; set; }

        public bool IsLastAction { get; set; }
        public int OrderId { get; set; }
        public bool Active { get; set; }

        // Relationships
        public User UserCreator { get; set; } = default!;
        public  EntryDetail EntryDetail { get; set; }
    
    }
}
