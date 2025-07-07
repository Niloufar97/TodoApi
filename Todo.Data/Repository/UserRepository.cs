using Microsoft.EntityFrameworkCore;
using Todo.Core.Domain;

namespace Todo.Data.Repository

{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<User?> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
