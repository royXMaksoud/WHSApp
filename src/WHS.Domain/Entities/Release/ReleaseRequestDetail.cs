using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Domain.Entities.Enntry;
using WHS.Domain.Entities.Entry;

namespace WHS.Domain.Entities.Release
{
    public class ReleaseRequestDetail
    {
        [Key]
        public Guid ReleaseRequestDetailGUID { get; set; }  // Primary Key
        public Guid ReleaseRequestGUID { get; set; } // Foreign Key to Request
        public Guid EntryDetailGUID { get; set; }  // Foreign Key to Entry Detail
        public Guid? EntryDetailPriceGUID { get; set; }  // Foreign Key to Entry Detail

        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Comments { get; set; } = default!;
        public required string D { get; set; }  // Value for the determiner (e.g., barcode, serial number)
        public bool Active { get; set; }
        public DateOnly CreateDate { get; set; }
        public DateOnly UpdateDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }
        // Relationships
        public  EntryDetail EntryDetail { get; set; }
        public  EntryDetailPrice EntryDetailPrice { get; set; }
        public  ReleaseRequest ReleaseRequest { get; set; }

    }
}
