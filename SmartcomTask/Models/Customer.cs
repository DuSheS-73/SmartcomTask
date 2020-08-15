using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Models
{
    public class Customer
    {
        [Required]
        //[ForeignKey("CustomerID")]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Имя заказчика")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Код заказчика")]
        public string Code { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Скидка")]
        public int Discount { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }

        //public List<Order> Orders { get; set; }
    }
}
