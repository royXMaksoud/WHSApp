using System.ComponentModel.DataAnnotations;

namespace WHS.Domain.Entities.Code
{
    public class Organization
    {
        [Key]
        public Guid OrganizationGUID { get; set; } // Primary Key
        public required string OrganizationName { get; set; }
        public required string OrganizationCode { get; set; }
        public required ICollection<InstitutionByCountry> InstitutionByCountries { get; set; }
    }
}