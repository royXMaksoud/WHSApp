using System.ComponentModel.DataAnnotations;
using WHS.Domain.Entities.Account;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.Enntry;

namespace WHS.Domain.Entities.Shipment
{
    public class ShipmentRequest
    {
        [Key]
        public Guid ShipmentRequestGUID { get; set; }  // Primary Key
        public Guid WarehouseGUID { get; set; } // Foreign Key to Warehouse
        public Guid ShipmentTypeGUID { get; set; }
        public Guid SupplierGUID { get; set; } // Foreign Key to Supplier      
        public int ShipmentNumber { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string Comments { get; set; } = default!;
        public bool Active { get; set; }
        public DateOnly CreateDate { get; set; }
        public DateOnly UpdateDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }

    


        // Relationships
        public ICollection<ShipmentRequestDetail> ShipmentDetails { get; set; } = [];

        public ICollection<ShipmentRequestMovement> ShipmentRequestMovements { get; set; } = [];

        // Navigation properties
        public User UserCreator { get; set; } = default!;

        public Warehouse Warehouse { get; set; }
        public Supplier Supplier { get; set; }  // This is the navigation property
    }

}
