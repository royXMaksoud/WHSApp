using WHS.Domain.Entities.Code;
using WHS.Domin.Constants;

namespace WHS.Domin.Services
{
    public interface IWarehouseAuthorizationService
    {
        bool Authorize(Warehouse warehosue, ResourceOperation resourceOperation);
    }
}