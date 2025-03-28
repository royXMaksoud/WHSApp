using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WHS.Application.Common.Queries;
using WHS.Application.Features.DynamicQueries;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DynamicQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DynamicQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("filter/{entityName}")]
        public async Task<IActionResult> FilterEntities(string entityName, [FromBody] DynamicQuery query)
        {
            // Get all types in WHS.Domain.Entities and log their names and full names
            var allEntities = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.Namespace != null && t.Namespace.StartsWith("WHS.Domain.Entities"))
                .Select(t => new { t.Name, t.FullName, t })  // Log both name, full name, and Type
                .ToList();

            // Log all available types and their namespaces
            Console.WriteLine($"Available entities (Name, FullName): {string.Join(", ", allEntities.Select(x => $"{x.Name} ({x.FullName})"))}");

            // Find the entity type dynamically, using case-insensitive comparison
            Type entityType = allEntities
                .FirstOrDefault(e => e.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase))?.t;

            if (entityType == null)
            {
                // Return BadRequest with the available entities to help debug if entity not found
                return BadRequest($"Invalid entity type. Available entities: {string.Join(", ", allEntities.Select(x => x.Name))}");
            }

            // Create the dynamic request type (IRequest<List<T>>)
            var requestType = typeof(GetDynamicQueryRequest<>).MakeGenericType(entityType);
            var request = Activator.CreateInstance(requestType, query);

            // Check if the request implements IRequest<List<T>> dynamically (using reflection)
            var isIRequest = requestType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest<>));
            if (!isIRequest)
            {
                return StatusCode(500, $"Request type '{requestType.FullName}' does not implement IRequest<> interface.");
            }

            // Get the MediatR Send method dynamically (with two parameters)
            var method = _mediator.GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name == "Send" && m.GetParameters().Length == 2);

            if (method == null)
                return StatusCode(500, "Failed to find MediatR Send method.");

            // Now, we use the correct response type for Send (which is List<T> or another suitable type)
            var result = method.MakeGenericMethod(typeof(List<>).MakeGenericType(entityType))
                .Invoke(_mediator, new object[] { request, default(CancellationToken) });

            return Ok(await (Task<object>)result);
        }


    }

}
