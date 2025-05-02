using Application.Authentication.DTOs;
using Application.Authentication.Interfaces;
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

        public UsersController(IUserAppService userService) =>
            _userService = userService;



        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> Post([FromBody] UserInput dto)
        {
            var id = await _userService.RegisterAsync(dto);

            var created = await _userService.GetById(id);

            return CreatedAtAction(
                nameof(Get),
                new { id = created.Id },
                created
            );
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserResponseDto>> Get([FromRoute] int id)
        {
            var user = await _userService.GetById(id);
            if (user is null)
                return NotFound();

            return Ok(user);
        }
    }
}
