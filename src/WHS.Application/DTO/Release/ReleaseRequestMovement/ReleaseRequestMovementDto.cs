using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Account.User;
using WHS.Application.DTO.Release.ReleaseRequest;

namespace WHS.Application.DTO.Release.ReleaseRequestMovement
{
    public class ReleaseRequestMovementDto
    {
        public Guid ReleaseRequestMovementGUID { get; set; }
        public Guid ReleaseRequestGUID { get; set; }
        public Guid FlowStatusGUID { get; set; }
        public string CreateById { get; set; } = default!;
        public bool IsLastAction { get; set; }
        public int OrderId { get; set; }
        public bool Active { get; set; }

        // Relationships
        public ReleaseRequestDto ReleaseRequest { get; set; } = default!;
        public UserDto User { get; set; } = default!;
    }

}
