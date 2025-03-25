using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WHS.Application.UserAuth;
using WHS.Domain.Entities.Account;
using WHS.Domain.Repositories;
using WHS.Domin.Services;
using WHS.Infrastructure.Authorization;
using WHS.Infrastructure.Authorization.Requirements.Warehouse;
using WHS.Infrastructure.Reporsitories;
using WHS.Infrastructure.Seeders;
using WHS.Infrastructure.Services;

namespace WHS.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //add connection string name
            var connectionString = configuration.GetConnectionString("WarehouseDb");
            //to add db context
            services.AddDbContext<WarehouseDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());
            //add IwaerhosueRepo to WarehouseRepo here will replace all actions in Iwarehouse wtih Repo

            //register asp.net identity user/role
            services.AddIdentityApiEndpoints<User>()
                .AddRoles<IdentityRole>()
                .AddClaimsPrincipalFactory<WHSUserClaimsPrincipalFactory>()
                .AddEntityFrameworkStores<WarehouseDbContext>();
            //register user context
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IWHSSeeder, WHSSeeder>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
            services.AddAuthorizationBuilder()
                .AddPolicy(PolicyNames.HasNationality, builder => builder.RequireClaim(AppClaimTypes.Nationality, "German", "Spain"))
                .AddPolicy(PolicyNames.AtLeast20, builder => builder.AddRequirements(new MinimumAgeRequirement(20)))
                .AddPolicy(PolicyNames.CreatedAtleast2Restaurants, builder => builder.AddRequirements(new CreatedMultipleWarehouseRequirements(2)));

            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
            services.AddScoped<IWarehouseAuthorizationService, WarehouseAuthorizationService>();

            services.AddHttpContextAccessor();
        }
    }
}