using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Domain.Entities.Release;

namespace WHS.Domain.Entities.Code
{
   public class RequesterType
    {
        [Key]
        public Guid RequesterTypeGUID { get; set; }  // Primary Key
        public required string RequesterName { get; set; }  //Warehosue , Staff, Partner, Other
        public required string RequesterCode { get; set; }
        public string Description { get; set; } = default!;
        public bool Active { get; set; }

        public ICollection<ReleaseRequest> ReleaseRequests { get; set; } = new List<ReleaseRequest>();
    }
}
