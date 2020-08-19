using SmartcomTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Domain.Repositories.Abstract
{
    public interface IUserRepository
    {
        IQueryable<ApplicationUser> GetUsers();
        ApplicationUser GetUserById(Guid? Id);
        List<string> UserCreateResult(ApplicationUser newUser);
        void DeleteUser(Guid Id);
    }
}
