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

        //public Customer GetCustomerByUserName(string UserName)
        //{
        //    return context.Users.FirstOrDefault(c => c.NormalizedUserName == UserName.ToUpper()).Customer;
        //}



        public void SaveCustomer(Customer entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
                context.Users.FirstOrDefault(c => c.UserName != "Admin" && c.Customer == default).Customer = entity;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void DeleteCustomer(Guid Id)
        {
            context.Customers.Remove(new Customer() { Id = Id });
        }

        
    }
}
