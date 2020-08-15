using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SmartcomTask.Domain.Repositories.Abstract;
using SmartcomTask.Models;
using System;
using System.Linq;

namespace SmartcomTask.Domain.Repositories.EntityFramework
{
    public class EFOrderElementRepository : IOrderElementRepository
    {
        private readonly AppDbContext context;
        public EFOrderElementRepository(AppDbContext context)
        {
            this.context = context;
        }


        public IQueryable<OrderElement> GetOrderElements()
        {
            return context.OrdersElements;
        }

        public IQueryable<OrderElement> GetOrderElementsBelongsToCustomer(Guid customerId)
        {
            //var orders = context.Orders.Where(c => c.CustomerId == customerId);
            return context.OrdersElements.Where(c => c.Order.CustomerId == customerId).OrderBy(o => o.Order.Status);
            //throw new NotImplementedException();
        }

        public OrderElement GetOrderElementById(Guid Id)
        {
            return context.OrdersElements.FirstOrDefault(c => c.ID == Id);
        }


        public void SaveOrderElement(OrderElement entity)
        {
            if (entity.ID == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void DeleteOrderElement(Guid id)
        {
            context.OrdersElements.Remove(new OrderElement() { ID = id });
        }
    }
}
