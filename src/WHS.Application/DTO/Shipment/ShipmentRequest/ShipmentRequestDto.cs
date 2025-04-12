using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Code.Supplier;
using WHS.Application.DTO.Entry.EntryDetail;
using WHS.Application.DTO.Shipment.ShipmentRequestDetail;
using WHS.Application.DTO.Shipment.ShipmentRequestMovements;

namespace WHS.Application.DTO.ShipmentDTO.ShipmentRequest
{
    public class ShipmentRequestDto
    {
        public Guid ShipmentRequestGUID { get; set; }
        public Guid WarehouseGUID { get; set; }
        public Guid ShipmentTypeGUID { get; set; }
        public Guid SupplierGUID { get; set; }
        public int ShipmentNumber { get; set; }
        public DateOnly ShipmentDate { get; set; }
        public string Comments { get; set; } = default!;
        public bool Active { get; set; }

        // Optional: You can include the related entities' properties, depending on your requirements.
        public WarehouseDto Warehouse { get; set; } = default!;
  
        public SupplierDto Supplier { get; set; } = default!;

        // Optionally, if you need the shipment details as well, you could include them:
        public ICollection<ShipmentRequestDetailDto> ShipmentDetails { get; set; } = new List<ShipmentRequestDetailDto>();
        public ICollection<ShipmentRequestMovemetnDto> ShipmentRequestMovemetnDtos { get; set; } = new List<ShipmentRequestMovemetnDto>();
    }

}
