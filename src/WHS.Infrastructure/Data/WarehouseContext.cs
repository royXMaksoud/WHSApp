// Infrastructure/Data/WarehouseContext.cs
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WHS.Domain.Entities.Account;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.WHS;

internal class WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<DutyStation> DutyStations { get; set; }
    public DbSet<CountryLocation> CountryLocations { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<WarehosueUser> WarehosueUser { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    //public DbSet<UserAccount> UserAccounts { get; set; }

    //public DbSet<UserRole> UserRoles { get; set; }
    //public DbSet<Role> Roles { get; set; }
    //public DbSet<Permission> Permissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Country - Organization (1-to-many)
        modelBuilder.Entity<Organization>()
            .HasOne(o => o.Country)
            .WithMany(c => c.Organizations)
            .HasForeignKey(o => o.CountryId)
            .OnDelete(DeleteBehavior.Cascade);

        // Country - CountryLocation (1-to-many)
        modelBuilder.Entity<CountryLocation>()
            .HasOne(cl => cl.Country)
            .WithMany(c => c.CountryLocations)
            .HasForeignKey(cl => cl.CountryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CountryLocation>()
            .HasKey(cl => cl.LocationId);  // Define the primary key for CountryLocation

        // Organization - DutyStation (1-to-many)

        modelBuilder.Entity<InventoryItem>()
            .HasOne(d => d.Product)
            .WithMany(o => o.InventoryItems)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Organization - DutyStation (1-to-many)
        modelBuilder.Entity<DutyStation>()
            .HasOne(d => d.Organization)
            .WithMany(o => o.DutyStations)
            .HasForeignKey(d => d.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);

        // Organization - Branch (1-to-many)
        modelBuilder.Entity<Branch>()
            .HasOne(b => b.Organization)
            .WithMany(o => o.Branches)
            .HasForeignKey(b => b.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);

        // Warehouse - DutyStation (many-to-1)
        modelBuilder.Entity<Warehouse>()
            .HasOne(w => w.DutyStation)
            .WithMany(d => d.Warehouses)
            .HasForeignKey(w => w.DutyStationId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete from DutyStation to Warehouse

        // Warehouse - Branch (many-to-1)
        modelBuilder.Entity<Warehouse>()
            .HasOne(w => w.Branch)
            .WithMany(b => b.Warehouses)
            .HasForeignKey(w => w.BranchId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete from Branch to Warehouse

        // Product - InventoryItem (1-to-many)
        modelBuilder.Entity<InventoryItem>()
            .HasOne(i => i.Product)
            .WithMany(p => p.InventoryItems)
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Warehouse - InventoryItem (many-to-1)
        modelBuilder.Entity<InventoryItem>()
            .HasOne(i => i.Warehouse)
            .WithMany()  // No need for a collection in Warehouse
            .HasForeignKey(i => i.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Order - OrderItem (1-to-many)
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // OrderItem - Product (many-to-1)
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Shipment - Order (many-to-1)
        modelBuilder.Entity<Shipment>()
            .HasOne(s => s.Order)
            .WithMany()
            .HasForeignKey(s => s.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // Transaction - InventoryItem (many-to-1)
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.InventoryItem)
            .WithMany()
            .HasForeignKey(t => t.InventoryItemId)
            .OnDelete(DeleteBehavior.Cascade);

        // modelBuilder.Entity<UserRole>()
        //.HasOne(ur => ur.UserAccount)
        //.WithMany(u => u.UserRoles)
        //.HasForeignKey(ur => ur.UserAccountId)
        //.OnDelete(DeleteBehavior.Cascade);

        // // UserRole - Role (many-to-1)
        // modelBuilder.Entity<UserRole>()
        //     .HasOne(ur => ur.Role)
        //     .WithMany(r => r.UserRoles)
        //     .HasForeignKey(ur => ur.RoleId)
        //     .OnDelete(DeleteBehavior.Cascade);

        // // RolePermission - Role (many-to-1)
        // modelBuilder.Entity<RolePermission>()
        //     .HasOne(rp => rp.Role)
        //     .WithMany(r => r.RolePermissions)
        //     .HasForeignKey(rp => rp.RoleId)
        //     .OnDelete(DeleteBehavior.Cascade);

        // // RolePermission - Permission (many-to-1)
        // modelBuilder.Entity<RolePermission>()
        //     .HasOne(rp => rp.Permission)
        //     .WithMany()
        //     .HasForeignKey(rp => rp.PermissionId)
        //     .OnDelete(DeleteBehavior.Cascade);

        // Define primary key for WarehouseFocalPoint
        modelBuilder.Entity<WarehosueUser>()
            .HasKey(wfp => wfp.WarehosueUserId); // Define the primary key

        // Define relationship between WarehouseFocalPoint and Warehouse
        modelBuilder.Entity<WarehosueUser>()
            .HasOne(wfp => wfp.Warehosue)
            .WithMany() // Warehouse can have many WarehouseFocalPoints (if needed, you can define a collection on Warehouse)
            .HasForeignKey(wfp => wfp.WarehouseId) // Foreign Key is WarehouseId
            .OnDelete(DeleteBehavior.Cascade); // Define delete behavior

        modelBuilder.Entity<User>()
            .HasMany(o => o.OwnedWarehouses)
            .WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId);
    }
}