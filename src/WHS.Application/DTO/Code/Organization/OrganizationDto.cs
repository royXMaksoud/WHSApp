using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Code.InstitutionByCountry;

namespace WHS.Application.DTO.Code.Organization
{
    public class OrganizationDto
    {
        public Guid OrganizationGUID { get; set; }
        public string OrganizationName { get; set; } = default!;
        public string OrganizationCode { get; set; } = default!;

        // Related InstitutionByCountries - represented as a list of InstitutionByCountryDto
        public ICollection<InstitutionByCountryDto> InstitutionByCountries { get; set; } = new List<InstitutionByCountryDto>();
    }
}
