using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WHS.Application.DTO.Dropdown
{
    public class DropdownValuesDto
    {
        public List<DropdownItemDto> ProductStatuses { get; set; } = new();
        public List<DropdownItemDto> MovementStatuses { get; set; } = new();
        public List<DropdownItemDto> PhysicalStatuses { get; set; } = new();
        public List<DropdownItemDto> Warehouses { get; set; } = new();
    }

    public class DropdownItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }

}