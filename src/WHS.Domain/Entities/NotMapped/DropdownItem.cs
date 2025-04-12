using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.NotMapped
{
    public class DropdownValues
    {
        public List<DropdownItem> ProductStatuses { get; set; } = new();
        public List<DropdownItem> MovementStatuses { get; set; } = new();
        public List<DropdownItem> PhysicalStatuses { get; set; } = new();
        public List<DropdownItem> Warehouses { get; set; } = new();
    }

    public class DropdownItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid? ParentGUID { get; set; }
        public Guid TableGUID { get; set; }
    }
}
