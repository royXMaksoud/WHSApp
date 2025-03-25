using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WHS.Domain.Constants;

namespace WHS.Infrastructure.Seeders
{
    internal class WHSSeeder(WarehouseDbContext dbContext) : IWHSSeeder
    {
        public async Task Seed()
        {
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                await dbContext.Database.MigrateAsync();
            }

            if (await dbContext.Database.CanConnectAsync())
            {
                //if (!dbContext.Warehouses.Any())
                //{
                //    var restaurants = GetRestaurants();
                //    dbContext.Warehouses.AddRange(Warehousess);
                //    await dbContext.SaveChangesAsync();
                //}

                if (!dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    dbContext.Roles.AddRange(roles);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles =
                [
                new (UserRoles.User)
                {
                    NormalizedName = UserRoles.User.ToUpper()
                },
                new (UserRoles.Owner)
                {
                    NormalizedName = UserRoles.Owner.ToUpper()
                },
                new (UserRoles.Admin)
                {
                    NormalizedName = UserRoles.Admin.ToUpper()
                },
            ];

            return roles;
        }
    }
}