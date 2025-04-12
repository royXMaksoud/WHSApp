using Microsoft.Extensions.Caching.Memory;
using WHS.Domain.Entities.NotMapped;
using WHS.Domain.Repositories.Dropdown;

public class CashServiceRepository : ICashServiceRepository
{
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _cacheDuration = TimeSpan.FromHours(24);

    public CashServiceRepository(IMemoryCache cache)
    {
        _cache = cache;
    }

    public async Task<List<DropdownItem>> GetCodeTableValuesAsync()
    {
        // Directly fetching from the cache, no dependency on DropdownRepository
        var result = await _cache.GetOrCreateAsync("CodeTableValues", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = _cacheDuration;

            // In case cache miss, fetch the data, this is a fallback that might be redundant if already managed in DropdownRepository
            return new List<DropdownItem>(); // Example: Replace with actual fallback logic
        });

        return result ?? new List<DropdownItem>();
    }

    public async Task<List<DropdownItem>> GetWarehousesAsync()
    {
        // Handle warehouse cache logic here
        var result = await _cache.GetOrCreateAsync("Warehouses", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = _cacheDuration;
            return new List<DropdownItem>(); // Example fallback, replace with actual data fetching logic
        });

        return result ?? new List<DropdownItem>();
    }

    public void ClearCache()
    {
        _cache.Remove("CodeTableValues");
        _cache.Remove("Warehouses");
    }
}
