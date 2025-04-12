using WHS.Domain.Entities.NotMapped;

namespace WHS.Domain.Repositories.Dropdown
{
    public interface IDropdownRepository
    {
        Task<List<DropdownItem>> GetCodeTableValuesAsync();
        Task<List<DropdownItem>> GetWarehousesAsync();

        Task<List<DropdownItem>> GetCascadeDropdownData(string entityName, Guid parentId);

    }
}
