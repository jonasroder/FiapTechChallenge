using Application.Gaming.Contracts;
using Application.SharedKernel.Extensions;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RawgController : ControllerBase
{
    private readonly IRawgService _rawgService;

    public RawgController(IRawgService rawgService)
    {
        _rawgService = rawgService;
    }


    [HttpGet]
    public async Task<IActionResult> GetGames()
    {
        var result = await _rawgService.GetGamesAsync();
        return result.ToActionResult();
    }
}
