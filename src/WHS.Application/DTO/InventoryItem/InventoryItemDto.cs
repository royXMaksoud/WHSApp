public class InventoryItemDto
{
    public Guid InventoryItemId { get; set; }
    public Guid WarehouseId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public WarehouseDto Warehouse { get; set; } = default!;
    //public Product Product { get; set; } = default!;
}