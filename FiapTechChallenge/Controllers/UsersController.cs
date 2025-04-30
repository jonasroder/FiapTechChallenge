using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiapTechChallenge.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userService;

        public UsersController(IUserAppService userService) =>
            _userService = userService;

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> Post([FromBody] UserInput dto)
        {
            // 1) Cria o usuário e obtém o Id
            var id = await _userService.RegisterAsync(dto);

            // 2) Busca o recurso completo
            var created = await _userService.GetById(id);

            // 3) Retorna 201 Created, Location + corpo com UserResponseDto
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
