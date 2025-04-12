using MediatR;
using WHS.Domain.Entities.NotMapped;
using WHS.Domain.Repositories.Dropdown;

namespace WHS.Application.CQRS.Dropdown;

public class GetDropdownValuesQuery : IRequest<DropdownValues>
{
}
public class GetDropdownValuesQueryHandler(IDropdownRepository dropdownRepository,
                                ICashServiceRepository cacheService) : IRequestHandler<GetDropdownValuesQuery, DropdownValues>
{
    public async Task<DropdownValues> Handle(GetDropdownValuesQuery request, CancellationToken cancellationToken)
    {
        var allCodeTables = await cacheService.GetCodeTableValuesAsync();
        var warehouses = await cacheService.GetWarehousesAsync();
        var _allCodeTables = await dropdownRepository.GetCodeTableValuesAsync();
        return new DropdownValues
        {
            ProductStatuses = _allCodeTables.Where(x=>x.TableGUID== Constants.CodeTableConstants.CurrentMovementStatusGUID)
                                            .Select(x=>new DropdownItem{ Id=x.Id, Name = x.Name})
                                             .ToList(),
            //MovementStatuses = await dropdownRepository.GetCodeTableValuesAsync("MovementStatus"),
            //PhysicalStatuses = await dropdownRepository.GetCodeTableValuesAsync("PhysicalStatus"),
            Warehouses = await dropdownRepository.GetWarehousesAsync()
        };
    }
}

