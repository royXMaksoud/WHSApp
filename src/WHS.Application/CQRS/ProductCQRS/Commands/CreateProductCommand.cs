using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.ProductCQRS.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string ProductName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string SKU { get; set; } = default!; // Stock Keeping Unit (unique identifier)
    }

    public class CreateProductCommandHandler(ILogger<CreateProductCommand> logger,
                                             IMapper mapper,
                                             IProductRepository prodcutRepository) : IRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new Product");
            var entity = mapper.Map<Product>(request);
            Guid id = await prodcutRepository.Create(entity);
            return id;
        }
    }
}