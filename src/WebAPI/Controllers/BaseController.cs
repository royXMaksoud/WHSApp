using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WHS.Application.Common;

namespace WebAPI.Controllers
{
    public class BaseController<TDto, TEntity, TCreateCommand, TUpdateCommand, TDeleteCommand, TGetQuery> : ControllerBase
        where TDto : class
        where TEntity : class
        where TCreateCommand : IRequest<Guid>
        where TUpdateCommand : IRequest
        where TDeleteCommand : IRequest
        where TGetQuery : IRequest<PageResult<TDto>> // <-- Updated to match the new query
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<PageResult<TDto>>> GetAll([FromQuery] TGetQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send((IRequest<TDto>)Activator.CreateInstance(typeof(TGetQuery), id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> Create([FromBody] TCreateCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Guid id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] TUpdateCommand command)
        {
            var updatedCommand = (TUpdateCommand)Activator.CreateInstance(typeof(TUpdateCommand), id);
            await _mediator.Send(updatedCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = (TDeleteCommand)Activator.CreateInstance(typeof(TDeleteCommand), id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
