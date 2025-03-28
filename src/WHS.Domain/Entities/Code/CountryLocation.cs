namespace WHS.Domain.Entities.Code
{
    public class CountryLocation
    {
        public Guid LocationId { get; set; } // Primary Key
        public Guid CountryId { get; set; } // Foreign Key to Country
        public required string LocationName { get; set; }

        // Navigation Property
        public required Country Country { get; set; }

        public required ICollection<Warehouse> Warehouses { get; set; }  // Related Warehouses
    }
}