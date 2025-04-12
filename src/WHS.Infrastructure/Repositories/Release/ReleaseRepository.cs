using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WHS.Application.Common;
using WHS.Domain.Entities.Release;
using WHS.Domain.Repositories.Release;

namespace WHS.Infrastructure.Repositories.Release
{

    public class ReleaseRequestRepository(WarehouseDbContext dbContext) : IReleaseRequestRepository
    {
        public async Task<Guid> Create(ReleaseRequest entity)
        {
            dbContext.ReleaseRequests.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.ReleaseRequestGUID;
        }

        public async Task Delete(ReleaseRequest entity)
        {
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReleaseRequest>> GetAllAsync()
        {
            var ReleaseRequests = await dbContext.ReleaseRequests.ToListAsync();
            return ReleaseRequests;
        }

        public async Task<(IEnumerable<ReleaseRequest>, int)> GetAllMatchingAsync(string? searchPhrase,
                                                                         int pageSize,
                                                                         int pageNumber,
                                                                         string? sortBy,
                                                                         SortDirection sortDirection)
        {
            var baseQuery = dbContext.ReleaseRequests.Where(x => searchPhrase == null ||
                                                                                x.SequenceCode.ToString().ToLower().Contains(searchPhrase));

            var totalCount = await baseQuery.CountAsync();
            if (sortBy != null)
            {
                var columnsSelector = new Dictionary<string, Expression<Func<ReleaseRequest, object>>>
            {
                    { nameof(ReleaseRequest.SequenceNumber),r=>r.SequenceNumber },
                     { nameof(ReleaseRequest.ReleaseDate),r=>r.ReleaseDate },
            };
                var selectedColumn = columnsSelector[sortBy];
                baseQuery = sortDirection == SortDirection.Ascending ? baseQuery.OrderBy(selectedColumn) : baseQuery.OrderByDescending(selectedColumn);
            }

            var searchPhraseLower = searchPhrase?.ToLower();
            var ReleaseRequests = await baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
            return (ReleaseRequests, totalCount);
        }

        public Task<(IEnumerable<ReleaseRequest>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, Domain.Constants.SortDirection sortDirection)
        {
            throw new NotImplementedException();
        }

        public async Task<ReleaseRequest?> GetByIdAsync(Guid id)
        {
            var ReleaseRequest = await dbContext.ReleaseRequests
                .Include(r => r.ReleaseRequestDetails)
                .FirstOrDefaultAsync(x => x.ReleaseRequestGUID == id);

            return ReleaseRequest;
        }

        public Task SaveChanges() => dbContext.SaveChangesAsync();
    }
}
