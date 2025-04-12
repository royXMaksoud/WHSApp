using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WHS.Domain.Constants;
using WHS.Domain.Entities.Shipment;
using WHS.Domain.Repositories.Shipment;

namespace WHS.Infrastructure.Repositories.Shipment
{
    class ShipmentRequestRepository(WarehouseDbContext dbContext) : IShipmentRequestRepository
    {
        public async Task<Guid> Create(ShipmentRequest entity)
        {
            dbContext.ShipmentRequests.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.ShipmentRequestGUID;
        }

        public async Task Delete(ShipmentRequest entity)
        {
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShipmentRequest>> GetAllAsync()
        {
            var ShipmentRequests = await dbContext.ShipmentRequests.ToListAsync();
            return ShipmentRequests;
        }

        public async Task<(IEnumerable<ShipmentRequest>, int)> GetAllMatchingAsync(string? searchPhrase,
                                                                         int pageSize,
                                                                         int pageNumber,
                                                                         string? sortBy,
                                                                         SortDirection sortDirection)
        {
            var baseQuery = dbContext.ShipmentRequests.Where(x => searchPhrase == null ||
                                                                                x.Comments.ToLower().Contains(searchPhrase));

            var totalCount = await baseQuery.CountAsync();
            if (sortBy != null)
            {
                var columnsSelector = new Dictionary<string, Expression<Func<ShipmentRequest, object>>>
            {
                    { nameof(ShipmentRequest.Comments),r=>r.Comments },
                     { nameof(ShipmentRequest.Comments),r=>r.Comments },
            };
                var selectedColumn = columnsSelector[sortBy];
                baseQuery = sortDirection == SortDirection.Ascending ? baseQuery.OrderBy(selectedColumn) : baseQuery.OrderByDescending(selectedColumn);
            }

            var searchPhraseLower = searchPhrase?.ToLower();
            var ShipmentRequests = await baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
            return (ShipmentRequests, totalCount);
        }

        public async Task<ShipmentRequest?> GetByIdAsync(Guid id)
        {
            var ShipmentRequest = await dbContext.ShipmentRequests
                .Include(r => r.ShipmentDetails)
                .FirstOrDefaultAsync(x => x.ShipmentRequestGUID == id);

            return ShipmentRequest;
        }

        public Task SaveChanges() => dbContext.SaveChangesAsync();
    }
}
