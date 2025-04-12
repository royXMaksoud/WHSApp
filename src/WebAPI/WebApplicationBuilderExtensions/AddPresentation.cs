using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using WebAPI.Middleware;
using WHS.Application.Filters;

namespace WebAPI.WebApplicationBuilderExtensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
                },
                []
            }
        });
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddScoped<RequestTimeLoggingMiddleware>();
            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<LogActionFilter>();

            builder.Services.AddControllersWithViews();


            builder.Host.UseSerilog((context, configuration) =>
                configuration
                              .MinimumLevel.Override("Microsft.EntityFrameWorkCore",LogEventLevel.Warning)
                              .WriteTo.File("Logs/Warehouse-API.log",rollingInterval:RollingInterval.Day,rollOnFileSizeLimit:true)
                              .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{Level:u3}] | {SourceContext} | {Message}{NewLine}{Exception}")
            );
            
        }
    }
}