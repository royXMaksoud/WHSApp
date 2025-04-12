using System.ComponentModel.DataAnnotations;
using WHS.Domain.Entities.Entry;

namespace WHS.Domain.Entities.Enntry
{
    public class EntryDeterminer
    {
        [Key]
        public Guid EntryDeterminerGUID { get; set; }  // Primary Key
        public Guid EntryDetailGUID { get; set; } // Foreign Key to Warehouse
        public Guid DeterminerTypeGUID { get; set; }  // Foreign Key to DeterminerType
        public required string DeterminerValue { get; set; }  // Value for the determiner (e.g., barcode, serial number)
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }

        public bool Active { get; set; }
        // Relationships
        public  EntryDetail EntryDetail { get; set; }
    }
}
