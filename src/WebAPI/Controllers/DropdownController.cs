using MediatR;
using Microsoft.AspNetCore.Mvc;
using WHS.Application.CQRS.Dropdown;
using WHS.Application.Filters;
using WHS.Domain.Repositories.Dropdown;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController(IMediator mediator) : ControllerBase
    {
        private readonly ICashServiceRepository cashService;
      
        [HttpGet]
        [ServiceFilter(typeof(LogActionFilter))]

        public async Task<IActionResult> GetDropdownValues()
        {
            var result = await mediator.Send(new GetDropdownValuesQuery());
            return Ok(result);
        }

        [HttpGet("GetCascadeDropdownData")]
        public async Task<IActionResult> GetCascadeDropdownData([FromQuery] string entityName, [FromQuery] string parentId)
        {
            var query = new GetCascadeDropdownDataQuery(entityName, Guid.Parse(parentId));
            var result = await mediator.Send(query);

            if (result!=null)
                return NotFound("No data found for the selected entity.");

            return Ok(result);
        }

        [HttpPost("refresh-cache")]
        public IActionResult RefreshCache()
        {
            cashService.ClearCache();
            return Ok("Dropdown cache refreshed!");
        }

    }
}
