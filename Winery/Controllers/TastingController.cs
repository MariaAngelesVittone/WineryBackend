using Common.Services;
using Data.DTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Winery.Controllers;

[ApiController]
[Route("api/tastings")]
[Authorize]
public class TastingController : ControllerBase
{
    private readonly ITastingService _tastingService;

    public TastingController(ITastingService tastingService)
    {
        _tastingService = tastingService;
    }

    [HttpPost]
    public IActionResult AddTasting([FromBody] TastingForCreationDTO tastingDto)
    {
        _tastingService.AddTasting(tastingDto);

        return Ok("La cata ha sido registrada exitosamente.");
    }

    [HttpPut("{tastingId}/guests")]
    public IActionResult AddGuests(int tastingId, [FromBody] List<string> newGuests)
    {
        _tastingService.AddGuests(tastingId, newGuests);

        return Ok("Invitados añadidos correctamente a la cata.");
    }

    [HttpGet("upcoming")]
    public IActionResult GetUpcomingTastings()
    {
        var upcomingTastings = _tastingService.GetUpcomingTastings();

        return Ok(upcomingTastings);
    }
}