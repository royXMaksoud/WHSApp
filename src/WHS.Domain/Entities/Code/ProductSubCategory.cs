using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.Code
{
    public class ProductSubCategory
    {
        [Key]
        public Guid ProductSubCategoryGUID { get; set; }  // Primary Key
        public Guid ProductCategoryGUID { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }

        // Relationships
        public ProductCategory ProductCategory { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

        // Translations for multilingual support
        //public ICollection<Translation> Translations { get; set; } = new List<Translation>();
    }



}
