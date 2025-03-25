using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Application.DTO.Product;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.ProductCQRS.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductDto>>
    {
    }

    public class GetAllProductQueryHandler(ILogger<GetAllProductQueryHandler> logger,
                                             IMapper mapper,
                                             IProductRepository currRepository) : IRequestHandler<GetAllProductQuery, IEnumerable<ProductDto>>
    {
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all product");
            var product = await currRepository.GetAllAsync();
            var currResult = mapper.Map<IEnumerable<ProductDto>>(product);
            return currResult!;
        }
    }
}