using WHS.Domain.Entities.Account;

namespace WHS.Domain.Entities.Code
{
    public class Warehouse
    {
        public Guid WarehouseId { get; set; } // Primary Key
        public string WarehouseName { get; set; } = default!;
        public Guid DutyStationId { get; set; } // Foreign Key to Duty Station
        public Guid BranchId { get; set; } // Foreign Key to Duty BRANCH

        // Navigation Properties
        public DutyStation DutyStation { get; set; } = default!;

        public Branch Branch { get; set; } = default!;

        public ICollection<warehouseUser> warehouseUsers { get; set; } = [];
        public User Owner { get; set; } = default!; 
        public string OwnerUserId { get; set; } = default!;
    }
}