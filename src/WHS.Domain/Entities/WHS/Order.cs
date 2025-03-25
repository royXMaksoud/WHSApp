namespace WHS.Domain.Entities.WHS
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; } // E.g., Pending, Shipped, Delivered
        public ICollection<OrderItem> OrderItems { get; set; } // Relationship to OrderItems
    }
}