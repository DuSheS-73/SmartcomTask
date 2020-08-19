using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.ViewModels
{
    public class EditUserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public int Discount { get; set; }
    }
}
