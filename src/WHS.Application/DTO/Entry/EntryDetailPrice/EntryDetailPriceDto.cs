using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Entry.EntryDetail;
using WHS.Application.DTO.Release.ReleaseRequestDetail;

namespace WHS.Application.DTO.Entry.EntryDetailPrice
{
    public class EntryDetailPriceDto
    {
        public Guid EntryDetailPriceGUID { get; set; }
        public Guid EntryDetailGUID { get; set; }
        public Guid PriceTypeGUID { get; set; }
        public decimal PriceValue { get; set; }
        public bool Active { get; set; }

        // Related EntryDetail - represented as EntryDetailDto
        public EntryDetailDto EntryDetail { get; set; } = default!;

        // Related ReleaseRequestDetails - represented as a list of ReleaseRequestDetailDto
        public ICollection<ReleaseRequestDetailDto> ReleaseRequestDetails { get; set; } = new List<ReleaseRequestDetailDto>();
    }
}
