namespace WHS.Domain.Entities.Code
{
    public class CountryLocation
    {
        public Guid LocationId { get; set; } // Primary Key
        public Guid CountryId { get; set; } // Foreign Key to Country
        public string LocationName { get; set; }

        // Navigation Property
        public Country Country { get; set; }

        public ICollection<Warehouse> Warehouses { get; set; }  // Related Warehouses
    }
}