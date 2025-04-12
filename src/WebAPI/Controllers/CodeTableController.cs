using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WHS.Application.CQRS.Code.CodeTableCQRS.Commands;
using WHS.Application.CQRS.Code.CodeTableCQRS.Queries;
using WHS.Application.DTO.Code.CodeTable;
using WHS.Domain.Constants;

namespace WebAPI.Controllers
{
    [Route("api/CodeTable")]
    [ApiController]
    public class CodeTableController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAll")]

        //[Authorize(Policy = PolicyNames.CreatedAtleast2Restaurants)]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CodeTableDto>>> GetAll([FromQuery] GetAllCodeTablesQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await mediator.Send(new GetCodeTableByIdQuery(id));
            return Ok(result);  
        }

        [HttpPost]
        [Authorize(Roles=UserRoles.Owner)]
        public async Task<IActionResult> CreateCodeTable([FromBody] CreateCodeTableCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Guid id=await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), id);
        }


        [HttpPatch("{id}")]
        [ProducesErrorResponseType(typeof(NoContent))]
        public async Task<IActionResult> UpdateCodeTable([FromRoute] Guid id, UpdateCodeTableCommand command)
        {
            command.TableId = id;
            await mediator.Send(command);

            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCodeTable([FromRoute] Guid id)
        {
            await mediator.Send(new DeleteCodeTableCommand(id));

            return NotFound();
        }

    }
}
