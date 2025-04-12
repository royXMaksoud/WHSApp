using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WHS.Domain.Entities.NotMapped;
using WHS.Domain.Repositories.Dropdown;

public class DropdownRepository : IDropdownRepository
{
    private readonly WarehouseDbContext _dbContext;
    private readonly IMemoryCache _cache;  // Injecting IMemoryCache here

    public DropdownRepository(WarehouseDbContext dbContext, IMemoryCache cache)
    {
        _dbContext = dbContext;
        _cache = cache;
    }

    public async Task<List<DropdownItem>> GetCodeTableValuesAsync()
    {
        // Attempt to retrieve from cache
        if (!_cache.TryGetValue("CodeTableValues", out List<DropdownItem> cachedValues))
        {
            // If not found in cache, fetch from the database
            cachedValues = await _dbContext.CodeTableValues.AsNoTracking()
                .Select(c => new DropdownItem
                {
                    Id = c.TableValueGUID,
                    Name = c.ValueName,
                    TableGUID = c.TableGUID
                })
                .ToListAsync();

            // Cache the result
            _cache.Set("CodeTableValues", cachedValues, TimeSpan.FromHours(24));
        }

        return cachedValues;
    }


    public async Task<List<DropdownItem>> GetWarehousesAsync()
    {
        // Attempt to retrieve from cache
        if (!_cache.TryGetValue("Warehouses", out List<DropdownItem> cachedWarehouses))
        {
            // Fetch from database or other source
            cachedWarehouses = await _dbContext.Warehouses.AsNoTracking()
                .Select(w => new DropdownItem
                {
                    Id = w.WarehouseGUID,
                    Name = w.WarehouseName
                })
                .ToListAsync();

            // Cache the result
            _cache.Set("Warehouses", cachedWarehouses, TimeSpan.FromHours(24));
        }

        return cachedWarehouses;
    }

    public async Task<List<DropdownItem>> GetCascadeDropdownData(string entityName, Guid parentId)
    {
        return entityName switch
        {
            "country" => await _dbContext.Countries
                .Select(c => new DropdownItem { Id = c.CountryGUID, Name = c.CountryName })
                .ToListAsync(),

            "CountryLocations" => await _dbContext.CountryLocations
                .Where(c => c.CountryGUID == parentId)
                .Select(c => new DropdownItem { Id = c.LocationGUID, Name = c.LocationName, ParentGUID = c.CountryGUID })
                .ToListAsync(),

            //"location" => await _dbContext.Locations
            //    .Where(l => l.CityId == parentId)
            //    .Select(l => new DropdownItem { Id = l.Id, Name = l.Name, Status = "N/A" })
            //    .ToListAsync(),

            _ => new List<DropdownItem>()
        };
    }

}
