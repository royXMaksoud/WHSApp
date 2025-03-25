using WHS.Domain.Entities.WHS;

namespace WHS.Domain.Entities.Code
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string SKU { get; set; } = default!; // Stock Keeping Unit (unique identifier)
        public ICollection<InventoryItem> InventoryItems { get; set; } // Relationship to InventoryItems
    }
}