using WHS.Application.DTO.Entry.EntryDetail;
using WHS.Application.DTO.Entry.EntryDetailPrice;
using WHS.Application.DTO.Release.ReleaseRequest;

namespace WHS.Application.DTO.Release.ReleaseRequestDetail
{
    public class ReleaseRequestDetailDto
    {
        public Guid ReleaseRequestDetailGUID { get; set; }
        public Guid ReleaseRequestGUID { get; set; }
        public Guid EntryDetailGUID { get; set; }
        public Guid? EntryDetailPriceGUID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Comments { get; set; } = default!;
        public string D { get; set; } = default!;
        public bool Active { get; set; }

        // Relationships
        public EntryDetailDto EntryDetail { get; set; } = default!;
        public EntryDetailPriceDto EntryDetailPrice { get; set; } = default!;
        public ReleaseRequestDto ReleaseRequest { get; set; } = default!;
    }

}
