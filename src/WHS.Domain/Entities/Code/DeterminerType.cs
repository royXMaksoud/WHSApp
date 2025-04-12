using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.Code
{
    public class DeterminerType
    {
        [Key]
        public Guid DeterminerTypeGUID { get; set; }  // Primary Key
        public required string TypeName { get; set; }  // Example: "Barcode", "Serial Number", "GSM"

        // Relationships
        public ICollection<ProductDeterminer> ProductDeterminers { get; set; } = new List<ProductDeterminer>();

        // Translations for multilingual support
        //public ICollection<Translation> Translations { get; set; } = new List<Translation>();
    }

}
