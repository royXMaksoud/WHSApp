using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WHS.Domain.Constants;
using WHS.Domain.Entities.Entry;
using WHS.Domain.Repositories.Entry;

namespace WHS.Infrastructure.Repositories.Entry
{
    public class EntryDetailRepository(WarehouseDbContext dbContext) : IEntryDetailRepository
    {
        public async Task<Guid> Create(EntryDetail entity)
        {
            dbContext.EntryDetails.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.EntryDetailGUID;
        }

        public async Task Delete(EntryDetail entity)
        {
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EntryDetail>> GetAllAsync()
        {
            var EntryDetails = await dbContext.EntryDetails.ToListAsync();
            return EntryDetails;
        }

        public async Task<(IEnumerable<EntryDetail>, int)> GetAllMatchingAsync(string? searchPhrase,
                                                                         int pageSize,
                                                                         int pageNumber,
                                                                         string? sortBy,
                                                                         SortDirection sortDirection)
        {
            var baseQuery = dbContext.EntryDetails.Where(x => searchPhrase == null ||
                                                                                x.Comments.ToLower().Contains(searchPhrase));

            var totalCount = await baseQuery.CountAsync();
            if (sortBy != null)
            {
                var columnsSelector = new Dictionary<string, Expression<Func<EntryDetail, object>>>
            {
                    { nameof(EntryDetail.Comments),r=>r.Comments },
                     { nameof(EntryDetail.Comments),r=>r.Comments },
            };
                var selectedColumn = columnsSelector[sortBy];
                baseQuery = sortDirection == SortDirection.Ascending ? baseQuery.OrderBy(selectedColumn) : baseQuery.OrderByDescending(selectedColumn);
            }

            var searchPhraseLower = searchPhrase?.ToLower();
            var EntryDetails = await baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
            return (EntryDetails, totalCount);
        }

        public async Task<EntryDetail?> GetByIdAsync(Guid id)
        {
            var EntryDetail = await dbContext.EntryDetails
                .Include(r => r.EntryDetailPrices)
                .FirstOrDefaultAsync(x => x.EntryDetailGUID == id);

            return EntryDetail;
        }

        public Task SaveChanges() => dbContext.SaveChangesAsync();
    }
}
