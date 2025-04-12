using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Domain.Entities.Account;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.Shipment;

namespace WHS.Domain.Entities.Release
{
    public class ReleaseRequest
    {
        [Key]
        public Guid ReleaseRequestGUID { get; set; }  // Primary Key
        public Guid RequestTypeGUID { get; set; } // Foreign Key to Request type (staff, warehouse)
        public Guid RequestNameGUID { get; set; }  // user , warehosue ,partner
        public Guid WarehouseUserGUID { get; set; }

        public Guid LastRequestStatusGUID { get; set; }// pending , confirmed 
        public int SequenceNumber { get; set; }
        public int SequenceCode { get; set; } // here  Year+Month+Sequence+Requester code +Warehouse codd +
        public int YearId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Active { get; set; }
        public User UserCreator { get; set; } = default!;
        public DateOnly CreateDate { get; set; }
        public DateOnly UpdateDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }

        //navigation
        public RequesterType RequesterType { get; set; }

        // Relationships
        public ICollection<ReleaseRequestDetail> ReleaseRequestDetails { get; set; } = new List<ReleaseRequestDetail>();
        public ICollection<ReleaseRequestMovement>  ReleaseRequestMovements { get; set; } = new List<ReleaseRequestMovement>();

        //public required WarehosueFocalPoint WarehosueFocalPoint { get; set; }
   


    }
}
