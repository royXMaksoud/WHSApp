using WHS.Domain.Constants;
using WHS.Domain.Entities.Code;

namespace WHS.Domain.Repositories
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();

        Task<Warehouse?> GetByIdAsync(Guid id);

        Task<Guid> Create(Warehouse warehouse);

        Task Delete(Warehouse warehouse);

        Task SaveChanges();

        Task<(IEnumerable<Warehouse>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);
    }
}