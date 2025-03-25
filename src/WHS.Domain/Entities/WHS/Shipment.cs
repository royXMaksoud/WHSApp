namespace WHS.Domain.Entities.WHS
{
    public class Shipment
    {
        public Guid ShipmentId { get; set; }
        public Guid OrderId { get; set; }  // Foreign key to Order
        public string TrackingNumber { get; set; } = default!;
        public DateTime ShipmentDate { get; set; }
        public string Carrier { get; set; } = default!;// E.g., FedEx, UPS
        public Order Order { get; set; }   // Navigation property to Order
    }
}