using SmartcomTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Domain.Repositories.Abstract
{
    public interface IItemsRepository
    {
        IQueryable<Item> GetItems();
        Item GetItemById(Guid? Id);
        Item GetItemByCode(string code);
        void SaveItem(Item entity);
        void DeleteItem(Guid Id);
    }
}
