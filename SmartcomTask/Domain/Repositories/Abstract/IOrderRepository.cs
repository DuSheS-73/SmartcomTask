using SmartcomTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Domain.Repositories.Abstract
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAllOrders(string status);
        IQueryable<Order> GetOrdersBelongsToCustomer(Guid customerId, string status);
        void SaveOrder(Order entity);
        void DeleteOrder(Guid Id);
    }
}
