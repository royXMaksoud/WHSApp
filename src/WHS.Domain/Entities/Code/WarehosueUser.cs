namespace WHS.Domain.Entities.Code
{
    public class WarehosueUser
    {
        public Guid WarehosueUserId { get; set; } // Primary Key

        public Guid WarehouseId { get; set; } // Foreign Key to Warehouse

        public DateTime? CreateDate { get; set; }

        // Navigation Properties
        public Warehouse Warehosue { get; set; }
    }
}