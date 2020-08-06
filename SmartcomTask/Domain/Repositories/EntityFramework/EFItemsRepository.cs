using Microsoft.EntityFrameworkCore;
using SmartcomTask.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartcomTask.Models;

namespace SmartcomTask.Domain.Repositories.EntityFramework
{
    public class EFItemsRepository : IItemsRepository
    {
        private readonly AppDbContext context;
        public EFItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Item> GetItems()
        {
            return context.Items;
        }
        
        public Item GetItemByCode(string code)
        {
            return context.Items.FirstOrDefault(i => i.Code == code);
        }

        public Item GetItemById(Guid? Id)
        {
            return context.Items.FirstOrDefault(i => i.ID == Id);
        }

        public void SaveItem(Item entity)
        {
            if (entity.ID == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteItem(Guid Id)
        {
            context.Items.Remove(new Item() { ID = Id });
        }

    }
}
