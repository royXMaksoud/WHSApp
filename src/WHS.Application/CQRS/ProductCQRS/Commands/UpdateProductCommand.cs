using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.ProductCQRS.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public Guid ProductId { get; set; } // Primary Key
        public string ProductName { get; set; }
    }

    public class UpdateProductCommandHandler(ILogger<UpdateProductCommand> logger, IProductRepository currRepository, AutoMapper.IMapper mapper) : IRequestHandler<UpdateProductCommand>

    {
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updateing warehosue with id: {request.ProductId}");
            var product = await currRepository.GetByIdAsync(request.ProductId);
            //if (warehouse is null)
            //    return false;
            mapper.Map(request, product);
            await currRepository.SaveChanges();
            //return true;
        }
    }
}