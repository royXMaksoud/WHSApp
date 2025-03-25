namespace WHS.Domain.Entities.Code
{
    public class Organization
    {
        public Guid OrganizationId { get; set; } // Primary Key
        public string OrganizationName { get; set; }
        public Guid CountryId { get; set; } // Foreign Key to Country

        // Navigation Properties
        public Country Country { get; set; }

        public ICollection<DutyStation> DutyStations { get; set; }  // Related Duty Stations
        public ICollection<Branch> Branches { get; set; }  // Related branches
    }
}