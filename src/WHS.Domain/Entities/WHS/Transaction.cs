namespace WHS.Domain.Entities.WHS
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid InventoryItemId { get; set; } // Foreign key to InventoryItem
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } // E.g., Addition, Removal, Adjustment
        public InventoryItem InventoryItem { get; set; }  // Navigation property to InventoryItem
    }
}