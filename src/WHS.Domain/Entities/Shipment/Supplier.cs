using System.ComponentModel.DataAnnotations;
using WHS.Domain.Entities.Account;
using WHS.Domain.Entities.Code;

namespace WHS.Domain.Entities.Shipment
{
    public class Supplier
    {
        [Key]
        public Guid SupplierGUID { get; set; }
        public Guid? LocationGUID { get; set; } // Foreign Key to Location from which country/location
        public required string Name { get; set; }
        public required string ContactName { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public CountryLocation CountryLocation { get; set; }

        public DateOnly CreateDate { get; set; }
        public DateOnly UpdateDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }

        //navigation
        public User UserCreator { get; set; }
        public ICollection<ShipmentRequest> ShipmentRequests { get; set; } = [];

    }
}
