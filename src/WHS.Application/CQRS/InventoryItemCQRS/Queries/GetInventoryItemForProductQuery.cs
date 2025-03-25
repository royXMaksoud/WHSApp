using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.InventoryItemCQRS.Queries;

public class GetInventoryItemForProductQuery(Guid productId) : IRequest<IEnumerable<InventoryItemDto>>
{
    public Guid ProductId { get; } = productId;
}

public class GetInventoryItemForProductQueryHandler(
                            ILogger<GetInventoryItemForProductQueryHandler> logger,
                            IMapper mapper,
                            IProductRepository productRepository
                        ) : IRequestHandler<GetInventoryItemForProductQuery, IEnumerable<InventoryItemDto>>
{
    public async Task<IEnumerable<InventoryItemDto>> Handle(GetInventoryItemForProductQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Reterieving dishes for products with id {ProductId}", request.ProductId);
        var product = await productRepository.GetByIdAsync(request.ProductId);
        if (product == null) throw new NotFoundException(nameof(Product), request.ProductId.ToString());
        var results = mapper.Map<IEnumerable<InventoryItemDto>>(product.InventoryItems);
        return results;
    }
}