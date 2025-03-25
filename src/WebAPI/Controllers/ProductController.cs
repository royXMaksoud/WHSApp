using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WHS.Application.CQRS.ProductCQRS.Commands;
using WHS.Application.CQRS.ProductCQRS.Queries;
using WHS.Application.DTO.Product;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await mediator.Send(new GetAllProductQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await mediator.Send(new GetProductByIdQuery(id));

            if (result is null)

                return NotFound();

            return Ok(result);
        }

        [HttpPatch("{id}")]
        [ProducesErrorResponseType(typeof(NoContent))]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, UpdateProductCommand command)
        {
            command.ProductId = id;
            await mediator.Send(command);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            await mediator.Send(new DeleteProductCommand(id));

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
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