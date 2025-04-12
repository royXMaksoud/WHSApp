using WHS.Application.DTO.Code.Product;
using WHS.Application.DTO.Entry.EntryDetail;
using WHS.Application.DTO.ShipmentDTO.ShipmentRequest;

namespace WHS.Application.DTO.Shipment.ShipmentRequestDetail
{
    public class ShipmentRequestDetailDto
    {
        public Guid ShipmentRequestDetailGUID { get; set; }
        public Guid ShipmentRequestGUID { get; set; }
        public Guid ProductGUID { get; set; }
        public int Quantity { get; set; }
        public decimal USDPrice { get; set; }
        public decimal LocalCurrencyPrice { get; set; }
        public decimal EuroPrice { get; set; }
        public Guid WarehoudGUID { get; set; }
        public string Comments { get; set; } = default!;
        public bool Active { get; set; }
        public DateOnly CreateDate { get; set; }
        public DateOnly UpdateDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }

        // Related ShipmentRequest - represented as ShipmentRequestDto
        public ShipmentRequestDto ShipmentRequest { get; set; } = default!;
        public ProductDto Product { get; set; }
        public ICollection<EntryDetailDto> EntryDetails { get; set; } = new List<EntryDetailDto>();
    }

}
