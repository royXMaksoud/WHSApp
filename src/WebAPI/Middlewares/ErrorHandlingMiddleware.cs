using WHS.Domain.Exceptions;

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
                await context.Response.WriteAsJsonAsync(new { message = notFound.Message, error = "NotFoundException" });
                _logger.LogWarning("NotFoundException occurred. Message: {Message}, Path: {Path}", notFound.Message, context.Request.Path);
            }
            catch (ForbidException)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Access forbidden");
            }
            catch (Exception ex)
            {
                // Log full exception details, including stack trace
                _logger.LogError(ex, "Unhandled exception occurred. Exception: {Message}, StackTrace: {StackTrace}, Path: {Path}", ex.Message, ex.StackTrace, context.Request.Path);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"Something went wrong. Exception: {ex.Message}");
            }
        }
    }
}