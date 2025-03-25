using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.WHS;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.InventoryItemCQRS.Commands;

public class CreateInventoryItemCommand : IRequest<Guid>
{
    public Guid WarehouseId { get; set; }  // Foreign key to Warehouse
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }     // How many units of the product are in the warehouse
    public decimal UnitPrice { get; set; } // Price per unit of product
}

public class CreateInventoryItemCommandHandler(ILogger<CreateInventoryItemCommandHandler> logger,
                                               IMapper mapper,
                                               IProductRepository productRepository,
                                               IInventoryItemRepository inventoryItemRepository) : IRequestHandler<CreateInventoryItemCommand, Guid>
{
    public async Task<Guid> Handle(CreateInventoryItemCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new Item :{@InventoryItemRequest}", request);
        var product = await productRepository.GetByIdAsync(request.ProductId);
        if (product == null) throw new NotFoundException(nameof(product), product.ProductId.ToString());
        var inventoryItem = mapper.Map<InventoryItem>(request);
        return await inventoryItemRepository.Create(inventoryItem);
    }
}