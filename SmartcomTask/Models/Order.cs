using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Models
{
    public class Order
    {
        [Required]
        //[ForeignKey("OrderID")]
        public Guid Id { get; set; }


        [Required]
        public Guid CustomerId { get; set; }
        //public Customer Customer { get; set; }


        [Required]
        [Display(Name = "Дата заказа")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Display(Name = "Дата доставки")]
        public DateTime? ShipmentDate { get; set; }

        [Display(Name = "Номер заказа")]
        public int OrderNumber { get; set; }

        [Display(Name = "Состояние заказа")]
        public string Status { get; set; }
    }
}
