using WHS.Domain.Constants;
using WHS.Domain.Entities.Entry;

namespace WHS.Domain.Repositories.Entry
{
    public interface IEntryDetailRepository
    {
        Task<IEnumerable<EntryDetail>> GetAllAsync();

        Task<EntryDetail?> GetByIdAsync(Guid id);

        Task<Guid> Create(EntryDetail EntryDetail);

        Task Delete(EntryDetail EntryDetail);

        Task SaveChanges();

        Task<(IEnumerable<EntryDetail>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);
    }
}
