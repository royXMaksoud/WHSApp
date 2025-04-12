using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Domain.Entities.Audit;
using WHS.Domain.Repositories.Audit;

namespace WHS.Infrastructure.Repositories.Audit
{
    public class ActionLogRepository(WarehouseDbContext dbContext) : IActionLogRepository
    {

        public async Task SaveActionLogAsync(ActionLog actionLog)
        {
            dbContext.ActionLogs.Add(actionLog);
            await dbContext.SaveChangesAsync();
        }
    }
}
