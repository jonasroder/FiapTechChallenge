using Application.Authentication.Contracts;
using Application.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;
using Application.SharedKernel.Extensions;


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
            var result = await _authService.LoginAsync(dto);
            return result.ToActionResult();
        }
    }
}
