using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Domain
{
    public class User : BaseEntity
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Username { get; set; }
        string Password { get; set; }  
        
        ICollection<Todo> Todos { get; set; }
    }
}
