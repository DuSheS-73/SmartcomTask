using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.ViewModels
{
    public class OrderStatusReceiveViewModel
    {
        public int StatusIndex { get; set; }

        private string[] Statuses = { "", "Новый", "Выполняется", "Выполнен" };

        public string GetStatus()
        {
            return Statuses[StatusIndex];
        }
    }
}
