using Application.Authentication.Interfaces;
using Application.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FiapTechChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest dto)
        {
            var token = await _authService.LoginAsync(dto);
             return Ok(token);
        }
    }
}
