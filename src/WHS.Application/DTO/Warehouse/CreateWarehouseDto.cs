using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.DTO.DutyStation;

namespace WHS.Application.DTO.Warehouse
{
    public class CreateWarehouseDto
    {
    
        public string WarehouseName { get; set; }
        public Guid DutyStationId { get; set; } // Foreign Key to Duty Station
        public Guid BranchId { get; set; } // Foreign Key to Duty BRANCH
        public string BranchName { get; set; }
        public string DutyStationName { get; set; }
        public DutyStationDto? DutyStation { get; set; }
    }
}
