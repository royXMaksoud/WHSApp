using WHS.Domain.Entities.Code;

namespace WHS.Domain.Entities.WHS
{
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; } // Foreign key to Order
        public Guid ProductId { get; set; } // Foreign key to Product
        public int Quantity { get; set; } // How many units are in the order
        public decimal Price { get; set; } // Price per unit at the time of the order
        public Order Order { get; set; } // Navigation property to Order
        public Product Product { get; set; } // Navigation property to Product
    }
}