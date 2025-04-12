using WHS.Application.DTO.Code.CountryLocation;
using WHS.Application.DTO.ShipmentDTO.ShipmentRequest;

namespace WHS.Application.DTO.Code.Supplier
{
    public class SupplierDto
    {
        public Guid SupplierGUID { get; set; }
        public Guid? LocationGUID { get; set; }
        public string Name { get; set; } = default!;
        public string ContactName { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;

        // CountryLocation DTO to expose related CountryLocation details
        public CountryLocationDto CountryLocation { get; set; } = default!;

        // Optional: Include a collection of related ShipmentRequests, you can include necessary properties of ShipmentRequest.
        public ICollection<ShipmentRequestDto> ShipmentRequests { get; set; } = new List<ShipmentRequestDto>();
    }

}
