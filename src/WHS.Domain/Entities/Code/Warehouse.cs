using System.ComponentModel.DataAnnotations;
using WHS.Domain.Entities.Account;
using WHS.Domain.Entities.Shipment;

namespace WHS.Domain.Entities.Code
{
    public class Warehouse
    {
        [Key]
        public Guid WarehouseGUID { get; set; } // Primary Key
        public required string WarehouseName { get; set; } = string.Empty;
        public string WarehouseCode { get; set; } = default!;
        public Guid DutyStationGUID { get; set; } // Foreign Key to Duty Station      
        public Guid? WarehouseParentGUID { get; set; } // Foreign Key to parent
        public DateOnly CreateDate { get; set; }
        public DateOnly UpdateDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }

        // Navigation Properties
        public User UserCreator { get; set; } = default!;
        public DutyStation DutyStation { get; set; } = default!;

        // Collections 
        public ICollection<WarehosueFocalPoint> WarehosueFocalPoints { get; set; } = new List<WarehosueFocalPoint>();
        public ICollection<ShipmentRequest> ShipmentRequests { get; set; } = new List<ShipmentRequest>();
        public ICollection<ProductByWarehouse> ProductByWarehouses { get; set; } = new List<ProductByWarehouse>();
  

    }

}