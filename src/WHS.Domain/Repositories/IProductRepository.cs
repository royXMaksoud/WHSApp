using WHS.Domain.Entities.Code;

namespace WHS.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(Guid id);

        Task<Guid> Create(Product entity);

        Task Delete(Product entity);

        Task SaveChanges();
    }
}