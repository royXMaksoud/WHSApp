using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Application.DTO.Code.Product
{
    public class ProductDto
    {
        public Guid ProductGUID { get; set; }  // Primary Key
        public Guid ProductSubCategoryGUID { get; set; }
        public Guid ProductTypeGUID { get; set; }
        public Guid BrandGUID { get; set; }
        public required string ProductName { get; set; } = default!;
        public string ProductCode { get; set; } = default!;

        // Optional collections (can be mapped if needed)
        public List<Guid> DeterminerIds { get; set; } = new List<Guid>();
        public List<Guid> FeatureIds { get; set; } = new List<Guid>();
        public List<Guid> ShipmentRequestDetailIds { get; set; } = new List<Guid>();
        public List<Guid> ProductByWarehouseIds { get; set; } = new List<Guid>();
        public List<Guid> TranslationIds { get; set; } = new List<Guid>();
    }
}
