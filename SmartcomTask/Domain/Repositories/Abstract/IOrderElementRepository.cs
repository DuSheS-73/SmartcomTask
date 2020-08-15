using SmartcomTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Domain.Repositories.Abstract
{
    public interface IOrderElementRepository
    {
        IQueryable<OrderElement> GetOrderElements();
        IQueryable<OrderElement> GetOrderElementsBelongsToCustomer(Guid customerId);
        OrderElement GetOrderElementById(Guid Id);
        void SaveOrderElement(OrderElement entity);
        void DeleteOrderElement(Guid id);
    }
}
