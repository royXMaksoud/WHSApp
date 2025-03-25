using WHS.Application.DTO.Warehouse;
using WHS.Domain.Entities.Code;

namespace WHS.Application.Services
{
    public interface IWarehosueService
    {
        Task<IEnumerable<WarehouseDto>> GetAllWarehouses();
        Task<WarehouseDto?> GetById(Guid id);
        //Task<Guid> Create(CreateWarehouseDto dto);
    }
}