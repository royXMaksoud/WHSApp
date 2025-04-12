using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WHS.Application.UserAuth;
using WHS.Domain.Entities.Account;
using WHS.Domain.Repositories.Audit;
using WHS.Domain.Repositories.Code;
using WHS.Domain.Repositories.Dropdown;
using WHS.Domain.Repositories.Entry;
using WHS.Domain.Repositories.Release;
using WHS.Domain.Repositories.Shipment;
using WHS.Domin.Services;
using WHS.Infrastructure.Authorization;
using WHS.Infrastructure.Authorization.Requirements.Warehouse;
using WHS.Infrastructure.Repositories.Audit;
using WHS.Infrastructure.Repositories.Code;
using WHS.Infrastructure.Repositories.Entry;
using WHS.Infrastructure.Repositories.Release;
using WHS.Infrastructure.Repositories.Shipment;
using WHS.Infrastructure.Seeders;

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
            //add IwaerhouseRepo to WarehouseRepo here will replace all actions in Iwarehouse wtih Repo

            //register asp.net identity user/role
            services.AddIdentityApiEndpoints<User>()
                .AddRoles<IdentityRole>()
                .AddClaimsPrincipalFactory<WHSUserClaimsPrincipalFactory>()
                .AddEntityFrameworkStores<WarehouseDbContext>();
            //register user context
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IWHSSeeder, WHSSeeder>();
            //DI for Repositories
            ////////////////////////////////////////
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();            
            services.AddScoped<IEntryDetailRepository, EntryDetailRepository>();
            services.AddScoped<ICodeTableRepository, CodeTableRepository>();
            services.AddScoped<IDropdownRepository, DropdownRepository>();
            services.AddScoped<ICashServiceRepository, CashServiceRepository>();
            services.AddScoped<IActionLogRepository, ActionLogRepository>();
            services.AddScoped<IShipmentRequestRepository, ShipmentRequestRepository>();
            services.AddScoped<IReleaseRequestRepository, ReleaseRequestRepository>();

            ////////////////////////////////////////

            services.AddAuthorizationBuilder()
                .AddPolicy(PolicyNames.HasNationality, builder => builder.RequireClaim(AppClaimTypes.Nationality, "German", "Spain"))
                .AddPolicy(PolicyNames.AtLeast20, builder => builder.AddRequirements(new MinimumAgeRequirement(20)))
                .AddPolicy(PolicyNames.CreatedAtleast2Warehouses, builder => builder.AddRequirements(new CreatedMultipleWarehouseRequirements(2)));

            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
            services.AddScoped(typeof(IAuthorizationService<>), typeof(AuthorizationService<>));



            services.AddHttpContextAccessor();
        }
    }
}