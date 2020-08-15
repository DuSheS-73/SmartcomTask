using Microsoft.EntityFrameworkCore;
using SmartcomTask.Domain.Repositories.Abstract;
using SmartcomTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Domain.Repositories.EntityFramework
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;
        public EFCustomerRepository(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }

        public IQueryable<Customer> GetCustomers()
        {
            return context.Customers;
        }

        public Customer GetCustomerById(Guid? Id)
        {
            return context.Customers.FirstOrDefault(c => c.Id == Id);
        }

        public Customer GetCustomerByUserName(string UserName)
        {
            if (UserName != null)
            {
                var appUser = context.Users.FirstOrDefault(c => c.UserName == UserName);
                return GetCustomerById(appUser.CustomerId);
            }
            return null;
        }



        public void SaveCustomer(Customer entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void DeleteCustomer(Guid id)
        {
            var customer = context.Customers.FirstOrDefault(c => c.Id == id);
            context.Entry(customer).State = EntityState.Deleted;
            //context.Customers.Remove(new Customer { Id = id });
        }

        
    }
}
