using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Release.ReleaseRequestDetail;
using WHS.Application.DTO.Release.ReleaseRequestMovement;
using WHS.Application.DTO.Release.RequesterType;

namespace WHS.Application.DTO.Release.ReleaseRequest
{
    public class ReleaseRequestDto
    {
        public Guid ReleaseRequestGUID { get; set; }
        public Guid RequestTypeGUID { get; set; }
        public Guid RequestNameGUID { get; set; }
        public Guid WarehouseUserGUID { get; set; }
        public Guid LastRequestStatusGUID { get; set; }
        public int SequenceNumber { get; set; }
        public int SequenceCode { get; set; }
        public int YearId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Active { get; set; }

        // Related ReleaseRequestDetails - represented as a list of ReleaseRequestDetailDto
        public ICollection<ReleaseRequestDetailDto> ReleaseRequestDetails { get; set; } = new List<ReleaseRequestDetailDto>();

        // Related ReleaseRequestMovements - represented as a list of ReleaseRequestMovementDto
        public ICollection<ReleaseRequestMovementDto> ReleaseRequestMovements { get; set; } = new List<ReleaseRequestMovementDto>();

        // Related RequesterType - represented as RequesterTypeDto
        public RequesterTypeDto RequesterType { get; set; } = default!;
    }

}
