using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.Code
{
    public class ProductCategory
    {
        [Key]
        public Guid ProductCategoryGUID { get; set; }  // Primary Key
        public string CategoryName { get; set; } = default!;
        public string Description { get; set; }

        // Relationships
        public ICollection<ProductSubCategory> SubCategories { get; set; } = new List<ProductSubCategory>();

        // Translations for multilingual support
        //public ICollection<Translation> Translations { get; set; } = new List<Translation>();
    }
}
