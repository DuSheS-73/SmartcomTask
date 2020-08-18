using Microsoft.EntityFrameworkCore;
using SmartcomTask.Domain.Repositories.Abstract;
using SmartcomTask.Models;
using System;
using System.Linq;

namespace SmartcomTask.Domain.Repositories.EntityFramework
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        public EFOrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Order> GetAllOrders()
        {
            return context.Orders.OrderBy(c => c.Status);
        }

        public IQueryable<Order> GetOrdersBelongsToCustomer(Guid customerId)
        {
           return context.Orders.Where(c => c.CustomerId == customerId).OrderBy(o => o.Status);
        }

        public void SaveOrder(Order entity)
        {
            if(entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void DeleteOrder(Guid Id)
        {
            context.Orders.Remove(new Order() { Id = Id });
        }
    }
}
