using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.Code
{
    public class InstitutionByCountry
    {
        [Key]
        public Guid InstitutionGUID { get; set; } // Primary Key
        public required string InstitutioName { get; set; }
        public Guid OrganizationGUID { get; set; } // Foreign Key to Organization
        public Guid CountryGUID { get; set; } // Foreign Key to Country
        public required Organization Organization { get; set; }       

        // Navigation Properties
        public required Country Country { get; set; }

        public required ICollection<DutyStation> DutyStations { get; set; }

    }
}
