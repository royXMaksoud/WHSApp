using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Code.Country;
using WHS.Application.DTO.Code.Supplier;

namespace WHS.Application.DTO.Code.CountryLocation
{
    public class CountryLocationDto
    {
        public Guid LocationGUID { get; set; }
        public Guid CountryGUID { get; set; }
        public string LocationName { get; set; } = default!;

        // Related Country information - you can include only the necessary properties from the Country entity
        public CountryDto Country { get; set; } = default!;

        // Related Suppliers - if needed, you can include a list of suppliers with their relevant properties
        public ICollection<SupplierDto> Suppliers { get; set; } = new List<SupplierDto>();
    }
}
