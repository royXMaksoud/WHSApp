using System.ComponentModel.DataAnnotations;

namespace WHS.Domain.Entities.Code
{
    public class DutyStation
    {
        [Key]
        public Guid DutyStationGUID { get; set; } // Primary Key
        public required string DutyStationName { get; set; }
        public Guid InstitutionGUID { get; set; } // Foreign Key to Organization

        // Navigation Properties
        public required InstitutionByCountry InstitutionByCountry { get; set; }

        public required ICollection<Warehouse> Warehouses { get; set; } = [];
    }
}