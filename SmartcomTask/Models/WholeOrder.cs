using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Models
{
    public class WholeOrder
    {
        public Order Order { get; set; }
        public OrderElement OrderElement { get; set; }
    }
}
