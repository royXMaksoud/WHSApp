using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Entry.EntryDetail;

namespace WHS.Application.DTO.Entry.EntryDeterminer
{
    public class EntryDeterminerDto
    {
        public Guid EntryDeterminerGUID { get; set; }
        public Guid EntryDetailGUID { get; set; }
        public Guid DeterminerTypeGUID { get; set; }
        public string DeterminerValue { get; set; } = default!;
        public bool Active { get; set; }

        // Related EntryDetail - represented as EntryDetailDto
        public EntryDetailDto EntryDetail { get; set; } = default!;
    }

}
