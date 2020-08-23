using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace SmartcomTask.Models
{
    public class Order
    {
        public Order() { }
        public Order(Guid customerId)
        {
            CustomerId = customerId;
            OrderNumber = new Random().Next();
            Status = "Новый";
            OrderDate = DateTime.Now;
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid CustomerId { get; set; }


        [Required]
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShipmentDate { get; set; }
        public int OrderNumber { get; set; }
        public string Status { get; set; }



        [NotMapped]
        public string OrderDateDisplay { get; set; }

        [NotMapped]
        public string ShipmentDateDisplay { get; set; }



        // sets the order status then returns list of possible errors
        public void SetStatus()
        {
            if (Status == "Новый")
            {
                // Let's suppose the company has fixed delivery time
                ShipmentDate = OrderDate.AddDays(20);
                Status = "Выполняется";
            }
            else if (Status == "Выполняется")
            {
                Status = "Выполнен";
            }
        }
    }
}
