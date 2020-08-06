using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Customer Customer { get; set; }
    }
}
