using System.ComponentModel.DataAnnotations;
using WHS.Domain.Entities.Account;
using WHS.Domain.Entities.Release;

namespace WHS.Domain.Entities.Code
{
    public class WarehosueFocalPoint
    {
        [Key]
        public Guid WarehosueFocalPointGUID { get; set; } // Primary Key

        public Guid WarehouseGUID { get; set; } // Foreign Key to Warehouse
        public required string UserFocalPointId { get; set; }
        public DateTime? CreateDate { get; set; }

        // Navigation Properties
        public Warehouse Warehouse { get; set; }

        public User UserFocalPoint { get; set; } = default!;
        //public ICollection<ReleaseRequest> ReleaseRequests { get; set; }=new List<ReleaseRequest>();    
       
    }
}