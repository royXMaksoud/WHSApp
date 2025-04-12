using WHS.Domain.Constants;
using WHS.Domain.Entities.Release;

namespace WHS.Domain.Repositories.Release
{
    public interface IReleaseRequestRepository
    {
        Task<IEnumerable<ReleaseRequest>> GetAllAsync();

        Task<ReleaseRequest?> GetByIdAsync(Guid id);

        Task<Guid> Create(ReleaseRequest ReleaseRequest);

        Task Delete(ReleaseRequest ReleaseRequest);

        Task SaveChanges();

        Task<(IEnumerable<ReleaseRequest>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);
    }
}
