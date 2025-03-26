using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Application.DTO.Product;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.ProductCQRS.Queries
{
    public class GetProductByIdQuery(Guid id) : IRequest<ProductDto>
    {
        public Guid Id { get; } = id;
    }

    public class GetProductByIdQueryHandler(ILogger<GetAllProductQueryHandler> logger,
                                            IMapper mapper,
                                            IProductRepository productRepository
                                            ) : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting product{request.Id}");
            var product = await productRepository.GetByIdAsync(request.Id);
            if (product is null)
                throw new NotFoundException(nameof(product), request.Id.ToString());
            //var warehouseDto = WarehouseDto.FromEntity(warehouse);
            var productDto = mapper.Map<ProductDto?>(product);
            return productDto;
        }
    }
}