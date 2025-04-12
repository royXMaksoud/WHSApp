using System.ComponentModel.DataAnnotations;
using WHS.Domain.Entities.Account;
using WHS.Domain.Entities.Enntry;
using WHS.Domain.Entities.Release;
using WHS.Domain.Entities.Shipment;


namespace WHS.Domain.Entities.Entry
{
    public class EntryDetail
    {
        [Key]
        public Guid EntryDetailGUID { get; set; }  // Primary Key
        public Guid ShipmentRequestDetailGUID { get; set; } // Foreign Key to Warehouse
        public Guid CurrentOwnedWarehousGUID { get; set; }
        public Guid CurrentProductStatusGUID { get; set; } //Funcational , GS45,Maintaince , not functioanl,
        public Guid CurrentMovementStatusGUID { get; set; } // confirmed,pending confirmed,
        public Guid CurrentPhysicalStatusGUID { get; set; } // in stock , in service ,GS45
        public int Quantity { get; set; } // 1 for product has SN/QR and number for consumable products 

        public decimal CurrentUSDPrice { get; set; } // Price per unit at the time of the orde
        public string Comments { get; set; } = default!;
        public string ProductName { get; set; } = default!;
        public DateOnly ShipmentDate { get; set; }
        
        public bool Active { get; set; }
      
        public DateOnly CreateDate { get; set; }
    
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }


        //navigation 
        public User UserCreator { get; set; } = default!;
          public ShipmentRequestDetail ShipmentRequestDetail { get; set; } 
        // Relationships
      
        public ICollection<EntryMovement> EntryMovements { get; set; } = new List<EntryMovement>();
        public ICollection<EntryDeterminer> EntryDeterminers { get; set; } = new List<EntryDeterminer>();
        public ICollection<EntryDetailPrice> EntryDetailPrices { get; set; } = new List<EntryDetailPrice>();
        public ICollection<ReleaseRequestDetail> ReleaseRequestDetails { get; set; } = new List<ReleaseRequestDetail>();
    }
}
