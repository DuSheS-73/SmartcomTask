using Microsoft.EntityFrameworkCore;
using SmartcomTask.Domain.Repositories.Abstract;
using SmartcomTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Domain.Repositories.EntityFramework
{
    public class EFUserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        public EFUserRepository(AppDbContext context)
        {
            this.context = context;
        }


        public IQueryable<ApplicationUser> GetUsers()
        {
            return context.Users.Where(c => c.UserName != "Admin");
        }

        public ApplicationUser GetUserById(Guid? Id)
        {
            return context.Users.FirstOrDefault(c => c.Id == Id);
        }

        public List<string> UserCreateResult(ApplicationUser newUser)
        {
            List<string> Errors = new List<string>();

            if (context.Users.FirstOrDefault(c => c.NormalizedUserName == newUser.NormalizedUserName) != null)
                Errors.Add("Пользователь с таким логином уже существует");

            if (context.Users.FirstOrDefault(c => c.NormalizedEmail == newUser.NormalizedEmail) != null)
                Errors.Add("Пользователь с таким Email уже существует");

            return Errors;
        }

        public void DeleteUser(Guid Id)
        {
            var user = context.Users.FirstOrDefault(u => u.Customer.Id == Id);
            context.Entry(user).State = EntityState.Deleted;
        }
    }
}
