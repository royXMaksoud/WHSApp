using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Domain.Entities.Audit;

namespace WHS.Domain.Repositories.Audit
{
    public interface IActionLogRepository
    {
        Task SaveActionLogAsync(ActionLog actionLog);
    }
}
