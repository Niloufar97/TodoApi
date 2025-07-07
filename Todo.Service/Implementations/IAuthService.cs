using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Domain;

namespace Todo.Service.Implementations
{
    public interface IAuthService
    {
        Task<User?> AuthenticateAsync(string username, string password);
        string GenerateJwtToken(User user);
    }
}
