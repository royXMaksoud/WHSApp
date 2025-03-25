using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.ProductCQRS.Commands
{
    public class DeleteProductCommand(Guid id) : IRequest
    {
        public Guid Id { get; } = id;
    }

    public class DeleteProductCommandHandler(ILogger<DeleteProductCommand> logger,
        IProductRepository currRespoitory) : IRequestHandler<DeleteProductCommand>
    {
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleteting Product with id :{request.Id}");
            var Product = await currRespoitory.GetByIdAsync(request.Id);
            if (Product is null)
                throw new NotFoundException(nameof(Product), request.Id.ToString());
            await currRespoitory.Delete(Product);
            //return true;
        }
    }
}