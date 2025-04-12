using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.Code
{
    public class ProductType
    {
        [Key]
        public Guid ProductTypeGUID { get; set; } // Primary Key
        public required string ProductTypeName { get; set; } // Consum,Has det

        // Navigation Properties
        public required ICollection<Product> Products { get; set; }  // Related Products

        
    }

}
