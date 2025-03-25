namespace WHS.Domain.Entities.Code
{
    public class Country
    {
        public Guid CountryId { get; set; } // Primary Key
        public string CountryName { get; set; }

        // Navigation Properties
        public ICollection<Organization> Organizations { get; set; }  // Related Organizations

        public ICollection<CountryLocation> CountryLocations { get; set; }  // Related User Locations
    }
}