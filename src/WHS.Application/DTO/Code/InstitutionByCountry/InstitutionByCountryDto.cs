using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Code.Country;
using WHS.Application.DTO.Code.DutyStation;
using WHS.Application.DTO.Code.Organization;

namespace WHS.Application.DTO.Code.InstitutionByCountry
{
    public class InstitutionByCountryDto
    {
        public Guid InstitutionGUID { get; set; }
        public string InstitutioName { get; set; } = default!;
        public Guid OrganizationGUID { get; set; }
        public Guid CountryGUID { get; set; }

        // Related Organization - represented as OrganizationDto
        public OrganizationDto Organization { get; set; } = default!;

        // Related Country - represented as CountryDto
        public CountryDto Country { get; set; } = default!;

        // Related DutyStations - represented as a list of DutyStationDto
        public ICollection<DutyStationDto> DutyStations { get; set; } = new List<DutyStationDto>();
    }
}
