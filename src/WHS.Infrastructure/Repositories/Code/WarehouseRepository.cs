using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WHS.Domain.Constants;
using WHS.Domain.Entities.Code;
using WHS.Domain.Repositories.Code;

namespace WHS.Infrastructure.Repositories.Code;

internal class WarehouseRepository(WarehouseDbContext dbContext) : IWarehouseRepository
{
    public async Task<Guid> Create(Warehouse entity)
    {
        dbContext.Warehouses.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.WarehouseGUID;
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

    public async Task<(IEnumerable<Warehouse>, int)> GetAllMatchingAsync(string? searchPhrase,
                                                                     int pageSize,
                                                                     int pageNumber,
                                                                     string? sortBy,
                                                                     SortDirection sortDirection)
    {
        var baseQuery = dbContext.Warehouses.Where(x => searchPhrase == null ||
                                                                            x.WarehouseName.ToLower().Contains(searchPhrase));

        var totalCount = await baseQuery.CountAsync();
        if (sortBy != null)
        {
            var columnsSelector = new Dictionary<string, Expression<Func<Warehouse, object>>>
            {
                    { nameof(Warehouse.WarehouseName),r=>r.WarehouseName },
                     { nameof(Warehouse.DutyStation),r=>r.DutyStation },
            };
            var selectedColumn = columnsSelector[sortBy];
            baseQuery = sortDirection == SortDirection.Ascending ? baseQuery.OrderBy(selectedColumn) : baseQuery.OrderByDescending(selectedColumn);
        }

        var searchPhraseLower = searchPhrase?.ToLower();
        var warehouses =await baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
        return (warehouses, totalCount);
    }

    public async Task<Warehouse?> GetByIdAsync(Guid id)
    {
        var warehouse = await dbContext.Warehouses
            .Include(r => r.WarehosueFocalPoints)
            .FirstOrDefaultAsync(x => x.WarehouseGUID== id);

        return warehouse;
    }

    public Task SaveChanges() => dbContext.SaveChangesAsync();
}