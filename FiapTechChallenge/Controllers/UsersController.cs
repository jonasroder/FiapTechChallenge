using Application.Authentication.Contracts;
using Application.Authentication.DTOs;
using Application.SharedKernel.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapTechChallenge.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userService;

        public UsersController(IUserAppService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous] // ou remova se quiser proteger o registro
        public async Task<IActionResult> Post([FromBody] UserInput dto)
        {
            var result = await _userService.RegisterAsync(dto);
            return result.ToActionResult();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _userService.GetById(id);
            return result.ToActionResult();
        }
    }
}
