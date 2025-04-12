using System.ComponentModel.DataAnnotations;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.Entry;

namespace WHS.Domain.Entities.Shipment
{
    public class ShipmentRequestDetail
    {
        [Key]
        public Guid ShipmentRequestDetailGUID { get; set; }  // Primary Key
        public Guid ShipmentRequestGUID { get; set; } // Foreign Key to Warehouse
        public Guid ProductGUID { get; set; }
        public int Quantity { get; set; } // How many units are in the order
        public decimal USDPrice { get; set; } // Price per unit at the time of the orde
        public decimal LocalCurrencyPrice { get; set; } // Price per unit at the time of the orde
        public decimal EruoPrice { get; set; } // Price per unit at the time of the orde
        public Guid WarehoudGUID { get; set; }
        public string Comments { get; set; } = default!;
        public DateOnly CreateDate { get; set; }
        public DateOnly UpdateDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }


        public bool Active { get; set; }

        // Relationships
        public ShipmentRequest ShipmentRequest { get; set; }

        //Multi
        public ICollection<EntryDetail> EntryDetails { get; set; } = new List<EntryDetail>();
        public Product Product { get; set; }

    }
}
