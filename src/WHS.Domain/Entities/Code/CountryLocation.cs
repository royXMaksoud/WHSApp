using System.ComponentModel.DataAnnotations;
using WHS.Domain.Entities.Shipment;

namespace WHS.Domain.Entities.Code
{
    public class CountryLocation
    {
        [Key]
        public Guid LocationGUID { get; set; } // Primary Key
        public Guid CountryGUID { get; set; } // Foreign Key to Country
        public required string LocationName { get; set; }

        // Navigation Property
        public required Country Country { get; set; }

        public required ICollection<Supplier> Suppliers { get; set; }  // Related Suppliers
    }
}