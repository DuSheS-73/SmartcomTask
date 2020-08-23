using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Models
{
    public class OrderElement
    {
        public OrderElement() { }
        public OrderElement(Order order, ShoppingCartItem item)
        {
            Order = order;
            Item = item.Item;
            ItemsCount = item.Amount;
            ItemPrice = item.Item.Price;
        }


        [Required]
        public Guid ID { get; set; }

        [Required]
        public virtual Order Order { get; set; }

        [Required]
        public Guid ItemID { get; set; }
        public virtual Item Item { get; set; }

        [Required]
        public int ItemsCount { get; set; }

        [Required]
        public int ItemPrice { get; set; }
    }
}
