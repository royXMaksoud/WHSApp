using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.Code
{
    public class Translation
    {
        [Key]
        public Guid TranslationGUID { get; set; }  // Primary Key

        public required string LanguageCode { get; set; }  // Example: "en", "ar"
        public required  string EntityType { get; set; }  // Name of the entity type being translated (e.g., "Product", "ProductCategory", etc.)
        public Guid EntityGUID { get; set; }  // The GUID of the entity being translated (foreign key to any entity)

        // Translation values
        public string Name { get; set; }  // The translated name for the entity

        // Optional: You can also store descriptions or other translation fields
        public string Description { get; set; } = default!;  // Example: A description of the entity in a specific language
    }

}
