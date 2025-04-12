using System.ComponentModel.DataAnnotations;
using WHS.Domain.Entities.Shipment;

namespace WHS.Domain.Entities.Code
{
    public class Product
    {
        [Key]
        public Guid ProductGUID { get; set; }  // Primary Key

        public Guid ProductSubCategoryGUID { get; set; }
        public Guid ProductTypeGUID { get; set; }
        public Guid BrandGUID { get; set; }
        public required string ProductName { get; set; } = default!;
        public string ProductCode { get; set; } = default!;
        public bool Active { get; set; }
        // Relationships
        public ICollection<ProductDeterminer> Determiners { get; set; } = new List<ProductDeterminer>();
        public ICollection<ProductFeature> Features { get; set; } = new List<ProductFeature>();
        public ICollection<ShipmentRequestDetail> ShipmentRequestDetails { get; set; } = new List<ShipmentRequestDetail>();


        // Foreign Key Relations
        public required ProductSubCategory ProductSubCategory { get; set; }
        public required Brand Brand { get; set; }

        public required ProductType ProductType { get; set; }

        // Translations for multilingual support
        public ICollection<Translation> Translations { get; set; } = new List<Translation>();
        //many to many with warehosue
        public ICollection<ProductByWarehouse> ProductByWarehouses { get; set; } = new List<ProductByWarehouse>();


    }
}