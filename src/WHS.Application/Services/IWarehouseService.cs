namespace WHS.Application.Services
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDto>> GetAllWarehouses();
        Task<WarehouseDto?> GetById(Guid id);
        //Task<Guid> Create(CreateWarehouseDto dto);
    }
}