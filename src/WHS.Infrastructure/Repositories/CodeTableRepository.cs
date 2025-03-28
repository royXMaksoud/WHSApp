using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WHS.Domain.Constants;
using WHS.Domain.Entities.Code;
using WHS.Domain.Repositories;

namespace WHS.Infrastructure.Repositories
{
    class CodeTableRepository(WarehouseDbContext dbContext) : ICodeTableRepository
    {
        public async Task<Guid> Create(CodeTable entity)
        {
            dbContext.CodeTable.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.TableId;
        }

        public async Task Delete(CodeTable entity)
        {
            dbContext.Remove(entity);   
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CodeTable>> GetAllAsync()
        {
            var result = await dbContext.CodeTable.ToListAsync();
            return result;  
        }

        public async Task<(IEnumerable<CodeTable>, int)> GetAllMatchingAsync(string? searchPhrase,
                                                                         int pageSize, int pageNumber, 
                                                                string? sortBy, SortDirection sortDirection)
        {
            var baseQuery = dbContext.CodeTable.Where(x => searchPhrase == null || (x.TableName.ToLower().Contains(x.TableName)));

            var totalCount=await baseQuery.CountAsync();
            if (sortBy != null)
            {
                var columnnSelector = new Dictionary<string, Expression<Func<CodeTable, object>>>
                {
                     { nameof(CodeTable.TableName),r=>r.TableName },
                     { nameof(CodeTable.CodeTableValues),r=>r.CodeTableValues },    
                };
                var selectedColumn = columnnSelector[sortBy];
                baseQuery = sortDirection == SortDirection.Ascending ? baseQuery.OrderBy(selectedColumn) : baseQuery.OrderByDescending(selectedColumn);
            }
            var searchPhraseLower = searchPhrase?.ToLower();
            var result = await baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
            return (result, totalCount);
            
        }

        public async Task<CodeTable?> GetByIdAsync(Guid id)
        {
            var result = await dbContext.CodeTable.Include(x => x.CodeTableValues).FirstOrDefaultAsync(x => x.TableId == id);
            return result;
        }

        public Task SaveChanges() => dbContext.SaveChangesAsync();
      
    }
}
