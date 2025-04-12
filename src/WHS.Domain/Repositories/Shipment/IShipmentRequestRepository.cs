using WHS.Domain.Constants;
using WHS.Domain.Entities.Shipment;

namespace WHS.Domain.Repositories.Shipment
{
    public interface IShipmentRequestRepository
    {
        Task<IEnumerable<ShipmentRequest>> GetAllAsync();

        Task<ShipmentRequest?> GetByIdAsync(Guid id);

        Task<Guid> Create(ShipmentRequest ShipmentRequest);

        Task Delete(ShipmentRequest ShipmentRequest);

        Task SaveChanges();

        Task<(IEnumerable<ShipmentRequest>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);
    }
}
