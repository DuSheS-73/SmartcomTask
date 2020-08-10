using SmartcomTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Domain.Repositories.Abstract
{
    public interface IWholeOrderRepository
    {
        IQueryable<WholeOrder> GetOrdersOrderedByStatus();
        void SaveOrder(Order order, OrderElement orderElement);
        
    }
}
