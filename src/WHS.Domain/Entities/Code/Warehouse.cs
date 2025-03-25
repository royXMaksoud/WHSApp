using WHS.Domain.Entities.Account;

namespace WHS.Domain.Entities.Code
{
    public class Warehouse
    {
        public Guid WarehouseId { get; set; } // Primary Key
        public string WarehouseName { get; set; }
        public Guid DutyStationId { get; set; } // Foreign Key to Duty Station
        public Guid BranchId { get; set; } // Foreign Key to Duty BRANCH

        // Navigation Properties
        public DutyStation DutyStation { get; set; }

        public Branch Branch { get; set; }

        public ICollection<WarehosueUser> WarehosueUsers { get; set; }
        public User Owner { get; set; }
        public string OwnerId { get; set; } = default!;
    }
}