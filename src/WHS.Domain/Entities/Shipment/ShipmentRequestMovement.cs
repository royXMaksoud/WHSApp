using System.ComponentModel.DataAnnotations;
using WHS.Domain.Entities.Account;

namespace WHS.Domain.Entities.Shipment
{
    public class ShipmentRequestMovement
    {
        [Key]
        public Guid ShipmentRequestMovementGUID { get; set; }  // Primary Key
        public Guid ShipmentRequestGUID { get; set; } // Foreign Key to Warehouse
        public Guid FlowStatusGUID { get; set; }
        
        public bool IsLastAction { get; set; }
        public int OrderId { get; set; }
        public DateOnly CreateDate { get; set; }
        public DateOnly UpdateDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }


        public string Comments { get; set; } = default!;
        public bool Active { get; set; }


        // Relationships
        public ShipmentRequest ShipmentRequest { get; set; } 
        public User UserCreator { get; set; } 
    }
}
