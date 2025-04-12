using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Domain.Entities.Enntry;
using WHS.Domain.Entities.Release;

namespace WHS.Domain.Entities.Entry
{
    public class EntryDetailPrice
    {
        [Key]
        public Guid EntryDetailPriceGUID { get; set; }  // Primary Key
        public Guid EntryDetailGUID { get; set; } // Foreign Key to Warehouse
        public Guid PriceTypeGUID { get; set; }  // Foreign Key to DeterminerType
        public required decimal PriceValue { get; set; }  // Value for the determiner (e.g., barcode, serial number)
        public bool Active { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }
        // Relationships
        public  EntryDetail EntryDetail { get; set; }
        public ICollection<ReleaseRequestDetail> ReleaseRequestDetails { get; set; } = new List<ReleaseRequestDetail>();
    }
}
