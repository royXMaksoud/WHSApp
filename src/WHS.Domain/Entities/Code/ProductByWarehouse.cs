using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Domain.Entities.Code
{
    public class ProductByWarehouse
    {
        [Key]
        public Guid ProductByWarehouseGUID { get; set; }  // Primary Key
        public Guid ProductGUID { get; set; }
        public Guid WarehouseGUID { get; set; }

        public Warehouse Warehouse { get; set; }

        public Product Product { get; set; }
    }
}
