namespace WHS.Domain.Entities.Code
{
    public class Country
    {
        public Guid CountryId { get; set; } // Primary Key
        public required string CountryName { get; set; }

        // Navigation Properties
        public required ICollection<Organization> Organizations { get; set; }  // Related Organizations

        public required ICollection<CountryLocation> CountryLocations { get; set; }  // Related User Locations
    }
}