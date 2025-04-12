using WHS.Domin.Constants;

namespace WHS.Domin.Services
{
    public interface IAuthorizationService<TEntity>
    {
        bool Authorize(TEntity entity, ResourceOperation resourceOperation);
    }
}