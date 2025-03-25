using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.WHS;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.InventoryItemCQRS.Queries
{
    public class GetInventoryItemByIdForProductQuery(Guid productId, Guid inventoryItemId) : IRequest<InventoryItemDto>
    {
        public Guid ProductId { get; } = productId;
        public Guid InventoryItemId { get; } = inventoryItemId;
    }

    public class GetInventoryItemByIdForProductQueryHandler(ILogger<GetInventoryItemByIdForProductQueryHandler> logger,
                                                            IProductRepository productRepository,
                                                            IMapper mapper
                                                            ) : IRequestHandler<GetInventoryItemByIdForProductQuery, InventoryItemDto>
    {
        public async Task<InventoryItemDto> Handle(GetInventoryItemByIdForProductQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving inventory item :{InventoryItemId}, for product with : {ProductId}", request.InventoryItemId, request.ProductId);
            var product = await productRepository.GetByIdAsync(request.ProductId);

            if (product == null) throw new NotFoundException(nameof(Product), request.ProductId.ToString());
            var inventoryItem = product.InventoryItems.FirstOrDefault(d => d.InventoryItemId == request.InventoryItemId);
            if (inventoryItem == null) throw new NotFoundException(nameof(InventoryItem), request.InventoryItemId.ToString());
            var results = mapper.Map<InventoryItemDto>(inventoryItem);
            return results;
        }
    }
}