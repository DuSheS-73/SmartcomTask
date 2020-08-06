using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Models
{
    public class Item
    {
        [Key]
        [Required]
        [ForeignKey("ItemID")]
        public Guid ID { get; set; }

        // Product code, format «XX-XXXX-YYXX» where Х – num , Y - english capital letter
        [Required]
        [Display(Name = "Код товара")]
        public string Code { get; set; }

        [Display(Name = "Наименование товара")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        [ForeignKey("ItemPrice")]
        public int Price { get; set; }

        [Display(Name = "Категория товара")]
        public string Category { get; set; }
    }
}
