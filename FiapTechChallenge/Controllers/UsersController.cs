using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiapTechChallenge.Controllers;
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserAppService _userService;

    public UsersController(IUserAppService userService) =>
        _userService = userService;


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserDto dto)
    {
        var id = await _userService.RegisterAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }



    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        
        return Ok();
    }
}