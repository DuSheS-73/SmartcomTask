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

        private void InitializeDateDisplayValues(IQueryable<Order> orders)
        {
            foreach (var order in orders)
            {
                order.OrderDateDisplay = order.OrderDate.ToString("dd/MM/yyyy");

                if (order.ShipmentDate != default)
                {
                    order.ShipmentDateDisplay = order.ShipmentDate.ToString("dd/MM/yyyy");
                }
            }
        }


        public IQueryable<Order> GetAllOrders(string status)
        {
            IQueryable<Order> orders;
            if (status == "")
            {
                orders = context.Orders.OrderByDescending(c => c.Status);
                
            }
            else
            {
                orders = context.Orders.Where(c => c.Status == status);
            }
            InitializeDateDisplayValues(orders);

            return orders;
        }

        public IQueryable<Order> GetOrdersBelongsToCustomer(Guid customerId, string status)
        {
            IQueryable<Order> orders;
            if (status == "")
            {
                orders = context.Orders.Where(c => c.CustomerId == customerId).OrderByDescending(o => o.Status);
            }
            else
            {
                orders = context.Orders.Where(c => c.CustomerId == customerId && c.Status == status);
            }
            InitializeDateDisplayValues(orders);

            return orders;
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
