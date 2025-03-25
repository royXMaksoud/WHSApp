namespace WHS.Domain.Entities.Code
{
    public class DutyStation
    {
        public Guid DutyStationId { get; set; } // Primary Key
        public string DutyStationName { get; set; }
        public Guid OrganizationId { get; set; } // Foreign Key to Organization

        // Navigation Properties
        public Organization Organization { get; set; }

        public ICollection<Warehouse> Warehouses { get; set; }
    }
}