using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.Code
{
    public class ProductDeterminer
    {
        [Key]
        public Guid ProductDeterminerGUID { get; set; }  // Primary Key
        public Guid ProductGUID { get; set; }
        public Guid DeterminerTypeGUID { get; set; }  // Foreign Key to DeterminerType
        
        // Relationships
        public Product Product { get; set; }
        public DeterminerType DeterminerType { get; set; }  // Foreign key navigation property

        // Translations for multilingual support
        //public ICollection<Translation> Translations { get; set; } = new List<Translation>();
    }

}
