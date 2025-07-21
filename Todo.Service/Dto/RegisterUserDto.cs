using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Service.Dto
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Username is required")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public required string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public required string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }

    }
}
