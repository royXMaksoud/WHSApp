using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WHS.Domain.Constants;
using WHS.Domain.Entities.Code;
using WHS.Domain.Repositories;

namespace WHS.Infrastructure.Reporsitories;

internal class WarehouseRepository(WarehouseDbContext dbContext) : IWarehouseRepository
{
    public async Task<Guid> Create(Warehouse entity)
    {
        dbContext.Warehouses.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.WarehouseId;
    }

    public async Task Delete(Warehouse entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Warehouse>> GetAllAsync()
    {
        var warehouses = await dbContext.Warehouses.ToListAsync();
        return warehouses;
    }

    public async Task<(IEnumerable<Warehouse>, int)> GetAllMatchingAsync(
        string? searchPhrase,
        int pageSize,
        int pageNumber,
        string? sortBy,
        SortDirection sortDirection)
    {
        try
        {
            // Build the base query with search phrase filtering
            var baseQuery = dbContext.Warehouses.AsQueryable();

            if (!string.IsNullOrEmpty(searchPhrase))
            {
                var searchPhraseLower = searchPhrase.ToLower(); // Only need to do this once
                baseQuery = baseQuery.Where(x => x.WarehouseName.ToLower().Contains(searchPhraseLower));
            }

            // Get total count of filtered records
            var totalCount = await baseQuery.CountAsync();

            // Sorting logic
            if (!string.IsNullOrEmpty(sortBy) && new Dictionary<string, Expression<Func<Warehouse, object>>>
        {
            { nameof(Warehouse.WarehouseName), r => r.WarehouseName },
            { nameof(Warehouse.DutyStation), r => r.DutyStation }
        }.TryGetValue(sortBy, out var sortExpression))
            {
                baseQuery = sortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(sortExpression)
                    : baseQuery.OrderByDescending(sortExpression);
            }

            // Fetch the actual warehouses with paging
            var warehouses = await baseQuery
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (warehouses, totalCount);
        }
        catch (Exception ex)
        {
            // Log error if necessary, and throw a custom exception
            // logger.LogError(ex, "Error occurred while fetching warehouses from the repository.");
            throw new ApplicationException("Error occurred while fetching warehouses.", ex);
        }
    }
    public async Task<Warehouse?> GetByIdAsync(Guid id)
    {
        var warehouse = await dbContext.Warehouses
            .Include(r => r.warehouseUsers)  // Ensure this is necessary for performance
            .FirstOrDefaultAsync(x => x.WarehouseId == id);

        return warehouse;  // If not found, this will return null, which is valid due to `Warehouse?`
    }



    public Task SaveChanges() => dbContext.SaveChangesAsync();
}