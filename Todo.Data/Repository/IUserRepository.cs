using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Domain;

namespace Todo.Data.Repository
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User?> GetUserByUsername(string username);
        Task<User?> GetUserByUsernameAndPassword(string username, string password);
    }
}
