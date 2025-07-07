using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Todo.Service.Dto;
using Todo.Service.Implementations;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
        
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
        {
            var user = await _authService.AuthenticateAsync(requestDto.Username, requestDto.Password);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }
            var token = _authService.GenerateJwtToken(user);
            return Ok(new {Token = token});
        }
    }
}
