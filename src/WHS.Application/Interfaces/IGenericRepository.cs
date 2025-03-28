using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.Common.Queries;
using WHS.Domain.Entities;

namespace WHS.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetFilteredAsync(DynamicQuery query, CancellationToken cancellationToken);
    }
}
