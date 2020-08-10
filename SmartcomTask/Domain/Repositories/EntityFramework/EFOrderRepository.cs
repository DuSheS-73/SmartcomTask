using Microsoft.EntityFrameworkCore;
using SmartcomTask.Domain.Repositories.Abstract;
using SmartcomTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Domain.Repositories.EntityFramework
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        public EFOrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Order> GetOrdersByStatus()
        {
            return context.Orders.OrderBy(c => c.Status);
        }

        public void SaveOrder(Order entity)
        {
            if(entity.ID == default)
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
            context.Orders.Remove(new Order() { ID = Id });
        }
    }
}
