using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.Code
{
    public class ProductFeature
    {
        [Key]
        public Guid ProductFeatureGUID { get; set; }  // Primary Key
        public Guid ProductGUID { get; set; }
        public string FeatureName { get; set; }  // Example: Weight, Color
        public string FeatureValue { get; set; }  // Value of the feature

        // Relationships
        public Product Product { get; set; }

        // Translations for multilingual support
        //public ICollection<Translation> Translations { get; set; } = new List<Translation>();
    }

}
