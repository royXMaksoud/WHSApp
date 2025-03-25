using WHS.Domain.Entities.Code;

namespace WHS.Domain.Entities.WHS
{
    public class InventoryItem
    {
        public Guid InventoryItemId { get; set; }
        public Guid WarehouseId { get; set; }  // Foreign key to Warehouse
        public Guid ProductId { get; set; }    // Foreign key to Product
        public int Quantity { get; set; }     // How many units of the product are in the warehouse
        public decimal UnitPrice { get; set; } // Price per unit of product
        public Warehouse Warehouse { get; set; }  // Navigation property to Warehouse
        public Product Product { get; set; } = default!;    // Navigation property to Product
    }
}