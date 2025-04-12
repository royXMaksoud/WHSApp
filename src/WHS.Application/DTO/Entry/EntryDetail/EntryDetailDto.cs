using WHS.Application.DTO.Entry.EntryDetailPrice;
using WHS.Application.DTO.Entry.EntryDeterminer;
using WHS.Application.DTO.Entry.EntryMovement;
using WHS.Application.DTO.Release.ReleaseRequestDetail;
using WHS.Application.DTO.Shipment.ShipmentRequestDetail;

namespace WHS.Application.DTO.Entry.EntryDetail
{
    public class EntryDetailDto
    {
        public Guid EntryDetailGUID { get; set; }
        public string ProductName { get; set; } = default!;
        public int ShipmentNumber { get; set; }
        public DateOnly ShipmentDate { get; set; }
        public decimal USDPrice { get; set; }
        public decimal LocalCurrencyPrice { get; set; }
        public decimal EuroPrice { get; set; }
    
        public int Quantity { get; set; }
        public decimal CurrentUSDPrice { get; set; }
        public string Comments { get; set; } = default!;
        public bool Active { get; set; }
        public Guid ShipmentRequestDetailGUID { get; set; }
        public Guid CurrentOwnedWarehousGUID { get; set; }
        public Guid CurrentProductStatusGUID { get; set; }
        public Guid CurrentMovementStatusGUID { get; set; }
        public Guid CurrentPhysicalStatusGUID { get; set; }
 

        // Optional: Depending on what you need, you could include related entities or their specific properties
        public ICollection<ShipmentRequestDetailDto> ShipmentRequestDetailDtos { get; set; } = new List<ShipmentRequestDetailDto>();
        public ICollection<EntryMovementDto> EntryMovements { get; set; } = new List<EntryMovementDto>();
        public ICollection<EntryDeterminerDto> EntryDeterminers { get; set; } = new List<EntryDeterminerDto>();
        public ICollection<EntryDetailPriceDto> EntryDetailPrices { get; set; } = new List<EntryDetailPriceDto>();
        public ICollection<ReleaseRequestDetailDto> ReleaseRequestDetails { get; set; } = new List<ReleaseRequestDetailDto>();

    }
}
