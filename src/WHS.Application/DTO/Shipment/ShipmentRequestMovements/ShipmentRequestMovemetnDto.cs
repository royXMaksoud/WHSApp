using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.Account.User;
using WHS.Application.DTO.ShipmentDTO.ShipmentRequest;
using WHS.Domain.Entities.Shipment;

namespace WHS.Application.DTO.Shipment.ShipmentRequestMovements
{
    public class ShipmentRequestMovemetnDto
    {
        public Guid ShipmentRequestMovementGUID { get; set; }  // Primary Key
        public Guid ShipmentRequestGUID { get; set; } // Foreign Key to Warehouse
        public Guid FlowStatusGUID { get; set; }

        public bool IsLastAction { get; set; }
        public int OrderId { get; set; }
        public DateOnly CreateDate { get; set; }
        public DateOnly UpdateDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }


        public string Comments { get; set; } = default!;
        public bool Active { get; set; }


        // Relationships
        public ShipmentRequestDto ShipmentRequest { get; set; }
        public UserDto UserCreator { get; set; }
    }
}
