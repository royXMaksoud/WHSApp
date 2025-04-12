using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Domain.Constants;
using WHS.Domain.Entities.Code;
using WHS.Domain.Repositories.Code;

namespace WHS.Infrastructure.Repositories.Code
{
    class TableRepository(WarehouseDbContext dbContext) : ICodeTableRepository
    {
        public Task<Guid> Create(CodeTable CodeTable)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CodeTable CodeTable)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CodeTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<CodeTable>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection)
        {
            throw new NotImplementedException();
        }

        public Task<CodeTable?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
