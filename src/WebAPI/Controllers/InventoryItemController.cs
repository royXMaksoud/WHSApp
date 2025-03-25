using MediatR;
using Microsoft.AspNetCore.Mvc;
using WHS.Application.CQRS.InventoryItemCQRS.Commands;
using WHS.Application.CQRS.InventoryItemCQRS.Queries;

namespace WebAPI.Controllers
{
    [Route("api/product/{productId}/InventoryItem")]
    [ApiController]
    public class InventoryItemController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateInventoryItem([FromRoute] Guid productId, CreateInventoryItemCommand command)
        {
            command.ProductId = productId;
            var producatId = await mediator.Send(command);
            //call GetInventoryItemByIdForProductQuery and takes two parameters
            return CreatedAtAction(nameof(GetInventoryItemByIdForProductQuery), new { productId, producatId }, null);
            //return Created();
        }

        [HttpGet]
        public async Task<ActionResult<InventoryItemDto>> GetAllForProduct([FromRoute] Guid productId)
        {
            var result = await mediator.Send(new GetInventoryItemForProductQuery(productId));
            return Ok(result);
        }

        [HttpGet("{inventoryItemId}")]
        public async Task<ActionResult<InventoryItemDto>> GetByIdForProduct([FromRoute] Guid productId, [FromRoute] Guid inventoryItemId)
        {
            var result = await mediator.Send(new GetInventoryItemByIdForProductQuery(productId, inventoryItemId));
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInventoryItemForProduct([FromRoute] Guid productId)
        {
            await mediator.Send(new DeleteInventoryItemForProductCommand(productId));
            return NoContent();
        }
    }
}