using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Models
{
    public class OrderElement
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        //public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Required]
        public virtual Item Item { get; set; }

        [Required]
        [Display(Name = "Количество")]
        public int ItemsCount { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public int ItemPrice { get; set; }
    }
}
