using WHS.Domain.Entities.WHS;

namespace WHS.Domain.Repositories;

public interface IInventoryItemRepository
{
    Task<Guid> Create(InventoryItem entity);

    Task Delete(IEnumerable<InventoryItem> items);
}