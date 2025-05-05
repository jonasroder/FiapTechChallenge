using Application.Gaming.Contracts;
using Microsoft.AspNetCore.Mvc;
using Application.SharedKernel.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class GameImporterController : ControllerBase
{
    private readonly IGameImporterService _importer;

    public GameImporterController(IGameImporterService importer)
    {
        _importer = importer;
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import()
    {
        var result = await _importer.ImportGamesAsync();
        return result.ToActionResult();
    }
}
