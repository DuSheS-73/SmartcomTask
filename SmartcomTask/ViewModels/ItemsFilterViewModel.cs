using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.ViewModels
{
    public class ItemsFilterViewModel
    {
        public string Category { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }

    }
}
