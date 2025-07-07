using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Domain;
using Todo.Data.Repository;

namespace Todo.Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            // Here you can add logic to hash the password if needed
            return await _userRepository.GetUserByUsernameAndPassword(username, password);
        }

        public string GenerateJwtToken(User user)
        {
            // 1. Create the secret key from config
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // 2. Create signing credentials using HMAC SHA256 algorithm
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 3. Define the claims - information embedded in the token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
                // You can add more claims here like roles or permissions
    };

            // 4. Create the JWT token object
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            // 5. Write the token as a string and return it
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
