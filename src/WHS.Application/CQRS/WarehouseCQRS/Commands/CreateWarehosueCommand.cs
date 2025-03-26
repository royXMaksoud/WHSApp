using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Application.DTO.DutyStation;
using WHS.Application.UserAuth;
using WHS.Domain.Entities.Code;
using WHS.Domain.Repositories;

namespace WHS.Application.CQRS.WarehouseCQRS.Commands;

public class CreateWarehouseCommand : IRequest<Guid>
{
    public string WarehouseName { get; set; } = default!;
    public Guid DutyStationId { get; set; } // Foreign Key to Duty Station
    public Guid BranchId { get; set; } // Foreign Key to Duty BRANCH
    public string BranchName { get; set; } = default!;
    public string DutyStationName { get; set; } = default!;
    public DutyStationDto? DutyStation { get; set; }
}

public class CreateWarehouseCommandHandler(ILogger<CreateWarehouseCommandHandler> logger,
                                           IMapper mapper,
                                           IWarehouseRepository warehouseRepository,
                                           IUserContext userContext) : IRequestHandler<CreateWarehouseCommand, Guid>
{
    public async Task<Guid> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        logger.LogInformation("{UserEmail} [{UserId}] is creating a new warehouse {@Warehouse}", currentUser.Email, currentUser.Id, request);
        var warehouse = mapper.Map<Warehouse>(request);
        // this need to be tested if correct in Project test
        warehouse.OwnerId = currentUser.Id;
        Guid id = await warehouseRepository.Create(warehouse);
        return id;
    }
}