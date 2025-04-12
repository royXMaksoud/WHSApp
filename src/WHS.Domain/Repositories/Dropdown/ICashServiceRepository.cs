using WHS.Domain.Entities.NotMapped;

namespace WHS.Domain.Repositories.Dropdown
{
    public interface ICashServiceRepository
    {
        Task<List<DropdownItem>> GetCodeTableValuesAsync();
        Task<List<DropdownItem>> GetWarehousesAsync();
      
        void ClearCache();
    }
}
