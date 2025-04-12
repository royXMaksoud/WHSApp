// Infrastructure/Data/WarehouseContext.cs
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WHS.Domain.Entities.Account;
using WHS.Domain.Entities.Audit;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.Enntry;
using WHS.Domain.Entities.Entry;
using WHS.Domain.Entities.Release;
using WHS.Domain.Entities.Shipment;

public class WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<CodeTable> CodeTables { get; set; }
    public DbSet<CodeTableValue> CodeTableValues { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryLocation> CountryLocations { get; set; }
    public DbSet<DeterminerType> DeterminerTypes { get; set; }
    public DbSet<DutyStation> DutyStations { get; set; }
    public DbSet<InstitutionByCountry> InstitutionByCountries { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductDeterminer> ProductDeterminers { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }
    public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<RequesterType> RequesterTypes { get; set; }
    public DbSet<Translation> Translations { get; set; }
    public DbSet<WarehosueFocalPoint> WarehosueFocalPoints { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<EntryDetail> EntryDetails { get; set; }
    public DbSet<EntryDetailPrice> EntryDetailPrices { get; set; }
    public DbSet<EntryDeterminer> EntryDeterminers { get; set; }
    public DbSet<EntryMovement> EntryMovements { get; set; }
    public DbSet<ShipmentRequest> ShipmentRequests { get; set; }
    public DbSet<ShipmentRequestDetail> ShipmentRequestDetails { get; set; }
    public DbSet<ShipmentRequestMovement> ShipmentRequestMovements { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<ReleaseRequest> ReleaseRequests { get; set; }
    public DbSet<ReleaseRequestDetail> ReleaseRequestDetails { get; set; }
    public DbSet<ReleaseRequestMovement> ReleaseRequestMovements { get; set; }
    public DbSet<ActionLog> ActionLogs { get; set; }

    // Add any additional configurations if needed
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Users : One-to-many relationship
        modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedWarehouses)
                .WithOne(w => w.UserCreator)
                .HasForeignKey(w => w.CreatedByUserId)
                   .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        modelBuilder.Entity<User>()
              .HasMany(u => u.OwnedCodeTables)
              .WithOne(w => w.UserCreator)
              .HasForeignKey(w => w.CreatedByUserId)
              .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        modelBuilder.Entity<User>()
          .HasMany(u => u.WarehosueFocalPoints)
          .WithOne(w => w.UserFocalPoint)
          .HasForeignKey(w => w.UserFocalPointId)
          .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        modelBuilder.Entity<User>()
        .HasMany(u => u.ShipmentRequestMovements)
        .WithOne(w => w.UserCreator)
        .HasForeignKey(w => w.CreatedByUserId).
        OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
        .HasMany(u => u.EntryMovements)
        .WithOne(w => w.UserCreator)
        .HasForeignKey(w => w.CreatedByUserId).
        OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
          .HasMany(u => u.EntryDetails)
          .WithOne(w => w.UserCreator)
          .HasForeignKey(w => w.CreatedByUserId).
          OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<Supplier>()
        //   .HasOne(s => s.UserCreator)
        //   .WithMany()  // Depending on your relationship, this might be different
        //   .HasForeignKey(s => s.CreatedByUserId)
        //   .OnDelete(DeleteBehavior.Restrict); // You can set cascading delete if needed

        modelBuilder.Entity<User>()
          .HasMany(u => u.ShipmentRequests)
          .WithOne(w => w.UserCreator)
          .HasForeignKey(w => w.CreatedByUserId).
          OnDelete(DeleteBehavior.Restrict);

        // branch
        modelBuilder.Entity<Brand>()
                .HasMany(u => u.Products)
                .WithOne(u => u.Brand)
                .HasForeignKey(u => u.BrandGUID)
                .OnDelete(DeleteBehavior.Restrict);

        // Code Table
        modelBuilder.Entity<CodeTable>()
            .HasMany(u => u.CodeTableValues)
            .WithOne(u => u.CodeTable)
            .HasForeignKey(u => u.TableGUID)
            .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        //Country
        modelBuilder.Entity<Country>()
           .HasMany(u => u.InstitutionByCountries)
           .WithOne(u => u.Country)
           .HasForeignKey(u => u.CountryGUID)
           .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        modelBuilder.Entity<Country>()
           .HasMany(u => u.CountryLocations)
           .WithOne(u => u.Country)
           .HasForeignKey(u => u.CountryGUID)
           .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        //CountryLocation
        modelBuilder.Entity<CountryLocation>()
           .HasMany(u => u.Suppliers)
           .WithOne(u => u.CountryLocation)
           .HasForeignKey(u => u.LocationGUID)
           .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        //ShipmentRequest
        modelBuilder.Entity<ShipmentRequest>()
        .HasOne(sr => sr.Supplier) // ShipmentRequest has one Supplier
        .WithMany(s => s.ShipmentRequests) // Supplier can have many ShipmentRequests
        .HasForeignKey(sr => sr.SupplierGUID) // Specify the foreign key
        .OnDelete(DeleteBehavior.Restrict); // Optional: set delete behavior

        //DeterminerType
        modelBuilder.Entity<DeterminerType>()
          .HasMany(u => u.ProductDeterminers)
          .WithOne(u => u.DeterminerType)
          .HasForeignKey(u => u.DeterminerTypeGUID)
          .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        //Organization

        modelBuilder.Entity<Organization>()
         .HasMany(u => u.InstitutionByCountries)
         .WithOne(u => u.Organization)
         .HasForeignKey(u => u.OrganizationGUID)
         .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        //Duty Station
        modelBuilder.Entity<DutyStation>()
            .HasMany(u => u.Warehouses)
            .WithOne(u => u.DutyStation)
            .HasForeignKey(u => u.DutyStationGUID)
            .OnDelete(DeleteBehavior.Restrict);

        //InstitutionByCountry

        modelBuilder.Entity<InstitutionByCountry>()
        .HasMany(u => u.DutyStations)
        .WithOne(u => u.InstitutionByCountry)
        .HasForeignKey(u => u.InstitutionGUID)
        .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        //Product
        modelBuilder.Entity<Product>()
        .HasMany(u => u.ShipmentRequestDetails)
        .WithOne(u => u.Product)
        .HasForeignKey(u => u.ProductGUID)
        .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        modelBuilder.Entity<Product>()
            .HasMany(u => u.Determiners)
            .WithOne(u => u.Product)
            .HasForeignKey(u => u.ProductGUID)
            .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        modelBuilder.Entity<Product>()
            .HasMany(u => u.Features)
            .WithOne(u => u.Product)
            .HasForeignKey(u => u.ProductGUID)
            .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior
                                                // Define the relationship between Product and ProductByWarehouse
        modelBuilder.Entity<Product>()
            .HasMany(p => p.ProductByWarehouses) // From Product to ProductByWarehouse
            .WithOne(pb => pb.Product) // From ProductByWarehouse to Product
            .HasForeignKey(pb => pb.ProductGUID);  // Foreign Key

        //Product Category
        modelBuilder.Entity<ProductCategory>()
            .HasMany(u => u.SubCategories)
            .WithOne(u => u.ProductCategory)
            .HasForeignKey(u => u.ProductCategoryGUID)
            .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior
                                                //Prodcut Sub Cateogry
        modelBuilder.Entity<ProductSubCategory>()
            .HasMany(u => u.Products)
            .WithOne(u => u.ProductSubCategory)
            .HasForeignKey(u => u.ProductSubCategoryGUID)
            .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        //Prodcut Type
        modelBuilder.Entity<ProductType>()
            .HasMany(u => u.Products)
            .WithOne(u => u.ProductType)
            .HasForeignKey(u => u.ProductTypeGUID)
            .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        //RequesterType
        modelBuilder.Entity<RequesterType>()
            .HasMany(u => u.ReleaseRequests)
            .WithOne(u => u.RequesterType)
            .HasForeignKey(u => u.RequestTypeGUID)
            .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior

        //Warehosue

        // Define the relationship between Warehouse and ProductByWarehouse
        modelBuilder.Entity<Warehouse>()
            .HasMany(w => w.ProductByWarehouses) // From Warehouse to ProductByWarehouse
            .WithOne(pb => pb.Warehouse) // From ProductByWarehouse to Warehouse
            .HasForeignKey(pb => pb.WarehouseGUID) // Foreign Key
          .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Warehouse>()
            .HasMany(w => w.ShipmentRequests) //
            .WithOne(pb => pb.Warehouse) //
            .HasForeignKey(pb => pb.WarehouseGUID) // Foreign Key
          .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Warehouse>()
            .HasMany(w => w.WarehosueFocalPoints) //
            .WithOne(pb => pb.Warehouse) //
            .HasForeignKey(pb => pb.WarehouseGUID) // Foreign Key
              .OnDelete(DeleteBehavior.Restrict);

        //Entry Detalis

        modelBuilder.Entity<EntryDetail>()
           .HasMany(w => w.EntryMovements) //
           .WithOne(pb => pb.EntryDetail) //
           .HasForeignKey(pb => pb.EntryMovementGUID) // Foreign Key
             .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EntryDetail>()
           .HasMany(w => w.EntryDeterminers) //
           .WithOne(pb => pb.EntryDetail) //
           .HasForeignKey(pb => pb.EntryDeterminerGUID) // Foreign Key
             .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EntryDetail>()
         .HasMany(w => w.EntryDetailPrices) //
         .WithOne(pb => pb.EntryDetail) //
         .HasForeignKey(pb => pb.EntryDetailPriceGUID) // Foreign Key
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EntryDetail>()
            .HasMany(w => w.ReleaseRequestDetails) //
            .WithOne(pb => pb.EntryDetail) //
            .HasForeignKey(pb => pb.ReleaseRequestDetailGUID) // Foreign Key
              .OnDelete(DeleteBehavior.Restrict);
        //detail price
        modelBuilder.Entity<EntryDetailPrice>()
         .HasMany(w => w.ReleaseRequestDetails) //
         .WithOne(pb => pb.EntryDetailPrice) //
         .HasForeignKey(pb => pb.ReleaseRequestDetailGUID) // Foreign Key
           .OnDelete(DeleteBehavior.Restrict);

        //ReleaseRequest
        modelBuilder.Entity<ShipmentRequest>()
            .HasOne(s => s.UserCreator)  // UserCreator is the navigation property
            .WithMany(u => u.ShipmentRequests)  // User has many ShipmentRequests
            .HasForeignKey(s => s.CreatedByUserId)  // Foreign key in ShipmentRequest table
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete if needed

        modelBuilder.Entity<ReleaseRequest>()
             .HasMany(w => w.ReleaseRequestDetails) //
             .WithOne(pb => pb.ReleaseRequest) //
             .HasForeignKey(pb => pb.ReleaseRequestDetailGUID) // Foreign Key
               .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ReleaseRequest>()
           .HasMany(w => w.ReleaseRequestMovements) //
           .WithOne(pb => pb.ReleaseRequest) //
           .HasForeignKey(pb => pb.ReleaseRequestMovementGUID) // Foreign Key
             .OnDelete(DeleteBehavior.Restrict);

        //shipment request
        modelBuilder.Entity<ShipmentRequest>()
        .HasMany(w => w.ShipmentDetails) //
        .WithOne(pb => pb.ShipmentRequest) //
        .HasForeignKey(pb => pb.ShipmentRequestGUID) // Foreign Key
          .OnDelete(DeleteBehavior.Restrict);
        //shipment request detail
        modelBuilder.Entity<ShipmentRequestDetail>()
          .HasMany(w => w.EntryDetails) //
          .WithOne(pb => pb.ShipmentRequestDetail) //
          .HasForeignKey(pb => pb.ShipmentRequestDetailGUID) // Foreign Key
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ShipmentRequest>()
              .HasMany(w => w.ShipmentRequestMovements) //
              .WithOne(pb => pb.ShipmentRequest) //
              .HasForeignKey(pb => pb.ShipmentRequestGUID) // Foreign Key
                .OnDelete(DeleteBehavior.Restrict);

        // Example: Many-to-many relationship between Product and Warehouse
        //modelBuilder.Entity<ProductByWarehouse>()
        //    .HasKey(pb => new { pb.ProductGUID, pb.WarehouseGUID });

        // More configurations based on your requirements
    }
}