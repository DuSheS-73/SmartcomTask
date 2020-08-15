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
        public IOrderRepository orderRepository { get; set; }
        public IOrderElementRepository orderElementRepository { get; set; }

        public DataManager(AppDbContext context,
                            IItemsRepository itemsRepository,
                            ICustomerRepository customerRepository,
                            IOrderRepository orderRepository,
                            IOrderElementRepository orderElementRepository)
        {
            this.context = context;
            this.itemsRepository = itemsRepository;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.orderElementRepository = orderElementRepository;
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
