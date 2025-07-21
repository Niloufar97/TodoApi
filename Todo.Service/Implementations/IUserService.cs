using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Service.Dto;

namespace Todo.Service.Implementations
{
    public interface IUserService
    {
        Task RegisterUser(RegisterUserDto userDto);
    }
}
