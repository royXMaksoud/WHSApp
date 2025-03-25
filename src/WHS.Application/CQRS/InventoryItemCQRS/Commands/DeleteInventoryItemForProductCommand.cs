using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.InventoryItemCQRS.Commands;

public class DeleteInventoryItemForProductCommand(Guid productId) : IRequest
{
    public Guid ProductId { get; set; } = productId;
}

public class DeleteInventoryItemForProductCommandHandler(ILogger<DeleteInventoryItemForProductCommandHandler> logger,
                                                         IProductRepository productRepository,
                                                         IInventoryItemRepository inventoryItemRepository) : IRequestHandler<DeleteInventoryItemForProductCommand>
{
    public async Task Handle(DeleteInventoryItemForProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Removing all inventory items from product {ProductId}", request.ProductId.ToString());
        var prodcut = await productRepository.GetByIdAsync(request.ProductId);
        if (prodcut == null) throw new NotFoundException(nameof(Product), request.ProductId.ToString());
        inventoryItemRepository.Delete(prodcut.InventoryItems);
    }
}