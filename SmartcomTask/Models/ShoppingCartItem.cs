using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public Guid ID { get; set; }

        public Guid ItemID { get; set; }
        public virtual Item Item { get; set; }

        public int Amount { get; set; }

        public Guid ShoppingCartID { get; set; }
    }
}
