using WHS.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context); // Continue to the next middleware
            }
            catch (NotFoundException notFound)
            {
                context.Response.StatusCode = 404;
                context.Response.ContentType = "application/json";
                var response = new { message = notFound.Message, error = "NotFoundException" };
                await context.Response.WriteAsJsonAsync(response);
                _logger.LogWarning("NotFoundException occurred. Message: {Message}, Path: {Path}", notFound.Message, context.Request.Path);
            }
            catch (ForbidException forbid)
            {
                context.Response.StatusCode = 403;
                context.Response.ContentType = "application/json";
                var response = new { message = forbid.Message, error = "ForbidException" };
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (ArgumentException argEx)
            {
                // Specific handling for invalid argument (e.g., invalid ID)
                context.Response.StatusCode = 400; // Bad Request
                context.Response.ContentType = "application/json";
                var response = new { message = argEx.Message, error = "ArgumentException" };
                await context.Response.WriteAsJsonAsync(response);
                _logger.LogWarning("ArgumentException occurred. Message: {Message}, Path: {Path}", argEx.Message, context.Request.Path);
            }
            catch (FormatException formatEx)
            {
                // Specific handling for incorrect format (e.g., wrong ID format)
                context.Response.StatusCode = 400; // Bad Request
                context.Response.ContentType = "application/json";
                var response = new { message = formatEx.Message, error = "FormatException" };
                await context.Response.WriteAsJsonAsync(response);
                _logger.LogWarning("FormatException occurred. Message: {Message}, Path: {Path}", formatEx.Message, context.Request.Path);
            }
            catch (Exception ex)
            {
                // Log all other unhandled exceptions with full details
                _logger.LogError(ex, "Unhandled exception occurred. Exception: {Message}, StackTrace: {StackTrace}, Path: {Path}, Method: {Method}",
                    ex.Message, ex.StackTrace, context.Request.Path, context.Request.Method);

                context.Response.StatusCode = 500; // Internal Server Error
                context.Response.ContentType = "application/json";
                var response = new { message = "Something went wrong.", error = ex.Message };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
