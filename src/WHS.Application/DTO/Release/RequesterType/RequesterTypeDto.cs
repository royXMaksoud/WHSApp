using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Release.ReleaseRequest;

namespace WHS.Application.DTO.Release.RequesterType
{
    public class RequesterTypeDto
    {
        public Guid RequesterTypeGUID { get; set; }
        public string RequesterName { get; set; } = default!;
        public string RequesterCode { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool Active { get; set; }

        // Related ReleaseRequests - represented as a list of ReleaseRequestDto
        public ICollection<ReleaseRequestDto> ReleaseRequests { get; set; } = new List<ReleaseRequestDto>();
    }

}
