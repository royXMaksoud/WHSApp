using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Application.Common.Queries
{
    public class DynamicQuery
    {
        public string EntityName { get; set; } = default!;// Name of the entity
        public string OrderBy { get; set; } = default!; // Sorting column
        public bool IsDescending { get; set; } // Order direction
        public List<FilterCondition> Filters { get; set; } = new(); // List of filters
    }

    public class FilterCondition
    {
        public string PropertyName { get; set; } = default!; // Entity property
        public string Operator { get; set; } = default!;// "==", "!=", "<", ">", "Contains"
        public string Value { get; set; } = default!; // Filter value
    }
}
