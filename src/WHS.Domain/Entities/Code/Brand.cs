using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.Code
{
    public class Brand
    {
        [Key]
        public Guid BrandGUID { get; set; } // Primary Key
        public string BrandName { get; set; } = default!;
        public string BrandDescription { get; set; } = default!;
        public bool Active { get; set; }
        public ICollection<Product> Products { get; set; } = [];
     
    }
}
