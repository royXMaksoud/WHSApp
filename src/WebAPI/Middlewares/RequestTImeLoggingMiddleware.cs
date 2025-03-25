using System.Diagnostics;

namespace WebAPI.Middleware
{
    public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stoppWatch = Stopwatch.StartNew();
            await next.Invoke(context);
            stoppWatch.Stop();
            if (stoppWatch.ElapsedMilliseconds / 1000 > 4)
            {
                logger.LogInformation("Request {Verb} ast {Path} took {Time} ms",
                    context.Request.Method,
                    context.Request.Path,
                    stoppWatch.ElapsedMilliseconds);
            }
        }
    }
}