using SmartcomTask.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Domain
{
    public class DataManager
    {
        private readonly AppDbContext context;
        public IItemsRepository itemsRepository { get; set; }
        public ICustomerRepository customerRepository { get; set; }

        public DataManager(AppDbContext context, IItemsRepository itemRepository, ICustomerRepository customerRepository)
        {
            this.context = context;
            this.itemsRepository = itemRepository;
            this.customerRepository = customerRepository;
        }  

        public async Task<int> Commit()
        {
            return await context.SaveChangesAsync();
        }

        public void Rollback()
        {
            context.Dispose();
        }
    }
}
