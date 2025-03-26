namespace WHS.Domain.Entities.Code
{
    public class warehouseUser
    {
        public Guid warehouseUserId { get; set; } // Primary Key

        public Guid WarehouseId { get; set; } // Foreign Key to Warehouse

        public DateTime? CreateDate { get; set; }

        // Navigation Properties
        public Warehouse warehouse { get; set; }
    }
}