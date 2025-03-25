using Serilog;
using WebAPI.Middleware;
using WebAPI.WebApplicationBuilderExtensions;
using WHS.Application.Extensions;
using WHS.Domain.Entities.Account;
using WHS.Infrastructure.Extensions;
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddApplication();
    builder.AddPresentation();
    builder.Services.AddInfrastructure(builder.Configuration);

    var app = builder.Build();
    app.UseMiddleware<ErrorHandlingMiddleware>(); // Use error handling middleware first
    app.UseMiddleware<RequestTimeLoggingMiddleware>();

    app.UseSerilogRequestLogging();
    builder.Logging.AddConsole();
    builder.Logging.AddDebug();
    //await seeder.Seed();
    // Configure the HTTP request pipeline
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger(); // Add Swagger middleware
        app.UseSwaggerUI(c =>  // Use Swagger UI middleware
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            c.RoutePrefix = string.Empty;  // Optional: make Swagger UI accessible at root
        });
    }
    app.UseRouting();
    app.UseHttpsRedirection();
    app.MapGroup("api/identity")
        .WithTags("Identity")
        .MapIdentityApi<User>();

    app.UseAuthorization();
    app.MapControllers();
    app.MapGet("", () => Results.Redirect("swagger/index.html"));

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application startup failed");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program
{ }