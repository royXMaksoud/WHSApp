using WHS.Domain.Entities.WHS;
using WHS.Domain.Repositories;

namespace WHS.Infrastructure.Reporsitories
{
    internal class InventoryItemRepository(WarehouseDbContext dbContext) : IInventoryItemRepository
    {
        public async Task<Guid> Create(InventoryItem entity)
        {
            dbContext.InventoryItems.Add(entity);
            await dbContext.SaveChangesAsync();

            return entity.InventoryItemId;
        }

        public async Task Delete(IEnumerable<InventoryItem> entities)
        {
            dbContext.InventoryItems.RemoveRange(entities);
            await dbContext.SaveChangesAsync();
        }
    }
}