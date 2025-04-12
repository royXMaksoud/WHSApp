using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WHS.Application.CQRS.Code.WarehouseCQRS.Commands;
using WHS.Application.CQRS.Entry.EntryDetailCQRS.Commands;
using WHS.Application.CQRS.Entry.EntryDetailCQRS.Queries;
using WHS.Application.DTO.Entry.EntryDetail;
using WHS.Domain.Constants;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryDetailController(IMediator mediator) : ControllerBase
    {
       
        [HttpGet("GetAll")]
        //[Authorize(Policy = PolicyNames.CreatedAtleast2Restaurants)]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<EntryDetailDto>>> GetAllEntryDetail([FromQuery] GetAllEntryDetailQuery query)
        {
            var warehouses = await mediator.Send(query);
            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await mediator.Send(new GetEntryDetialByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Owner)]
        public async Task<IActionResult> CreateEntryDetail([FromBody] CreateEntryDetailCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Guid id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
        [HttpPatch("{id}")]
        [ProducesErrorResponseType(typeof(NoContent))]
        public async Task<IActionResult> UpdateEntryDetail([FromRoute] Guid id, UpdateEntryDetailCommand command)
        {
            command.EntryDetailGUID = id;
            await mediator.Send(command);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntryDetail([FromRoute] Guid id)
        {
            await mediator.Send(new DeleteEntryDetailCommand(id));

            return NotFound();
        }

    }
}
