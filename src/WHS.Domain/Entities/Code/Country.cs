using System.ComponentModel.DataAnnotations;

namespace WHS.Domain.Entities.Code
{
    public class Country
    {
        [Key]
        public Guid CountryGUID { get; set; } // Primary Key
        public required string CountryName { get; set; }

        // Navigation Properties
        public required ICollection<InstitutionByCountry> InstitutionByCountries { get; set; }  // Related Organizations

        public required ICollection<CountryLocation> CountryLocations { get; set; }  // Related User Locations
    }
}