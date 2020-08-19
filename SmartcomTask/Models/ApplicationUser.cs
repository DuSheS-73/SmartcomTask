using Microsoft.AspNetCore.Identity;
using SmartcomTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser() { }
        public ApplicationUser(RegisterViewModel registrationModel)
        { 
            Id = Guid.NewGuid();
            UserName = registrationModel.UserName;
            NormalizedUserName = registrationModel.UserName.ToUpper();
            Email = registrationModel.Email;
            NormalizedEmail = registrationModel.Email.ToUpper();
            EmailConfirmed = true;
            PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(this, registrationModel.Password);
            Customer = new Customer
            {
                Name = registrationModel.Name,
                Address = registrationModel.Address,
                Code = new Random().Next(1000, 9999).ToString() + "-" + DateTime.Now.Year.ToString(),
                Discount = 0
            };
        }
        public virtual Customer Customer { get; set; }
    }
}
