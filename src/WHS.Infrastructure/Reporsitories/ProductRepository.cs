using Microsoft.EntityFrameworkCore;
using WHS.Domain.Entities.Code;
using WHS.Domain.Repositories;

namespace WHS.Infrastructure.Reporsitories
{
    internal class ProductRepository(WarehouseDbContext dbContext) : IProductRepository
    {
        public async Task<Guid> Create(Product entity)
        {
            dbContext.Products.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.ProductId;
        }

        public async Task Delete(Product entity)
        {
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var result = await dbContext.Products.ToListAsync();
            return result;
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            var product = await dbContext.Products
                       .Include(r => r.InventoryItems)
                       .FirstOrDefaultAsync(x => x.ProductId == id);

            return product;
        }

        public Task SaveChanges() => dbContext.SaveChangesAsync();
    }
}