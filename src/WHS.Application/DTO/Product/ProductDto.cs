namespace WHS.Application.DTO.Product;

public class ProductDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public string SKU { get; set; } = default!; // Stock Keeping Unit (unique identifier)
    public List<InventoryItemDto> InventoryItems { get; set; } = []!; // Relationship to InventoryItems
}