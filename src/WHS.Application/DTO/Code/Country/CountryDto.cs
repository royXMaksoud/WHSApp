using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Code.CountryLocation;
using WHS.Application.DTO.Code.InstitutionByCountry;

namespace WHS.Application.DTO.Code.Country
{
    public class CountryDto
    {
        public Guid CountryGUID { get; set; }
        public string CountryName { get; set; } = default!;

        // Related Institutions (Organizations) - represented as a list of InstitutionByCountryDto
        public ICollection<InstitutionByCountryDto> InstitutionByCountries { get; set; } = new List<InstitutionByCountryDto>();

        // Related CountryLocations - represented as a list of CountryLocationDto
        public ICollection<CountryLocationDto> CountryLocations { get; set; } = new List<CountryLocationDto>();
    }
}
