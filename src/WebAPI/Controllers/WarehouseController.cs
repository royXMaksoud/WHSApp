using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WHS.Application.CQRS.WarehouseCQRS.Commands;
using WHS.Application.CQRS.WarehouseCQRS.Queries;
using WHS.Domain.Constants;
using WHS.Infrastructure.Authorization;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/warehouse")]
    public class WarehouseController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAll")]
        //[Authorize(Policy = PolicyNames.CreatedAtleast2Restaurants)]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetAll([FromQuery] GetAllWarehousesQuery query)
        {
            var warehouses = await mediator.Send(query);
            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        [Authorize(Policy =PolicyNames.HasNationality)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var warehouse = await mediator.Send(new GetWarehouseByIdQuery(id));

            if (warehouse is null)

                return NotFound();

            return Ok(warehouse);
        }

        [HttpPatch("{id}")]
        [ProducesErrorResponseType(typeof(NoContent))]
        public async Task<IActionResult> UpdateWarehouse([FromRoute] Guid id, UpdateWarehouseCommand command)
        {
            command.WarehouseId = id;
            await mediator.Send(command);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse([FromRoute] Guid id)
        {
            await mediator.Send(new DeleteWarehouseCommand(id));

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Owner)]
        public async Task<IActionResult> CreateWarehouse([FromBody] CreateWarehouseCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Guid id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}