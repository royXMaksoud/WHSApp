using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Account.User;
using WHS.Application.DTO.Code.CodeTableValue;
using WHS.Application.DTO.Entry.EntryDetail;
using WHS.Domain.Entities.Code;

namespace WHS.Application.DTO.Entry.EntryMovement
{
    public class EntryMovementDto
    {
        public Guid EntryMovementGUID { get; set; }
        public Guid EntryDetailGUID { get; set; }
        public String FLowStatusName { get; set; }
        public String UserName { get; set; }
        public bool IsLastAction { get; set; }
        public int OrderId { get; set; }
        public bool Active { get; set; }
        public Guid FlowStatusGUID { get; set; }
        public string CreatedByUserId { get; set; } = default!;
       

        // Related EntryDetail - represented as EntryDetailDto
        public EntryDetailDto EntryDetail { get; set; } = default!;

        // Related User - represented as UserDto
        public UserDto User { get; set; } = default!;

        public CodeTableValueDto CodeTableValueDto { get; set; } = default!;
    }

}
