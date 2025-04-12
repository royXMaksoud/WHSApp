using Microsoft.AspNetCore.Identity;
using WHS.Domain.Entities.Code;
using WHS.Domain.Entities.Enntry;
using WHS.Domain.Entities.Entry;
using WHS.Domain.Entities.Release;
using WHS.Domain.Entities.Shipment;

namespace WHS.Domain.Entities.Account
{
    public class User : IdentityUser
    {
        public string? Nationality { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public ICollection<Warehouse> CreatedWarehouses { get; set; } = [];
        public ICollection<WarehosueFocalPoint> WarehosueFocalPoints { get; set; } = [];
        public ICollection<CodeTable> OwnedCodeTables { get; set; } = [];
        public ICollection<ShipmentRequestMovement> ShipmentRequestMovements { get; set; } = [];
        public ICollection<EntryMovement> EntryMovements { get; set; } = [];
        public ICollection<ReleaseRequestMovement> ReleaseRequestMovements { get; set; } = [];
        public ICollection<EntryDetail> EntryDetails { get; set; } = [];
        public ICollection<ReleaseRequest> ReleaseRequests { get; set; } = [];
        public ICollection<ShipmentRequest> ShipmentRequests { get; set; } = [];
        public ICollection<Supplier> Suppliers { get; set; } = [];
        


    }
}