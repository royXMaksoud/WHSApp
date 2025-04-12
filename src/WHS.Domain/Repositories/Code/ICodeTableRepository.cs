using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Domain.Constants;
using WHS.Domain.Entities.Code;

namespace WHS.Domain.Repositories.Code
{
    public interface ICodeTableRepository
    {
        Task<IEnumerable<CodeTable>> GetAllAsync();

        Task<CodeTable?> GetByIdAsync(Guid id);

        Task<Guid> Create(CodeTable CodeTable);

        Task Delete(CodeTable CodeTable);

        Task SaveChanges();

        Task<(IEnumerable<CodeTable>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);
    }
}
