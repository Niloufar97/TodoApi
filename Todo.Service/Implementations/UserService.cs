using Todo.Core.Domain;
using Todo.Data.Repository;
using Todo.Service.Dto;
using Microsoft.AspNetCore.Identity;

namespace Todo.Service.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(
        IUserRepository userRepository,
        IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task RegisterUser(RegisterUserDto userDto)
    {
        var existingUser = await _userRepository.GetUserByUsername(userDto.Username);
        if (existingUser != null)
        {
            throw new InvalidOperationException("User already exists.");
        }

        var user = new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Username = userDto.Username,
            Email = userDto.Email,
            Password = string.Empty // Temporary to satisfy 'required'
        };

        // Hash the password using the user instance
        user.Password = _passwordHasher.HashPassword(user, userDto.Password);

        await _userRepository.AddUser(user);
    }
}

