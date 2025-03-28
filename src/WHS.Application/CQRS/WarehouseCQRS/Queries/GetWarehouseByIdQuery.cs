using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Code;
using WHS.Domain.Exceptions;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.WarehouseCQRS.Queries
{
    public class GetWarehouseByIdQuery(Guid id) : IRequest<WarehouseDto>
    {
        public Guid Id { get; } = id;
    }

    public class GetWarehouseByIdQueryHandler(ILogger<GetWarehouseByIdQuery> logger
                                     , IMapper mapper
                                     , IWarehouseRepository warehouseRepository) : IRequestHandler<GetWarehouseByIdQuery, WarehouseDto?>
    {
        public async Task<WarehouseDto> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting Warehouses{request.Id}");
            var tempResult = await warehouseRepository.GetByIdAsync(request.Id);
            if (tempResult is null)
                throw new NotFoundException(nameof(Warehouse), request.Id.ToString());
            //var warehouseDto = WarehouseDto.FromEntity(warehouse);
            var warehouseDto = mapper.Map<WarehouseDto?>(tempResult);
            return warehouseDto;
        }
    }
}