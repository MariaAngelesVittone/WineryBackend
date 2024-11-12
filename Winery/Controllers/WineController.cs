using Microsoft.AspNetCore.Mvc;
using Common.Services;
using Data.DTO_s;

namespace Winery.Controllers;

[ApiController]
[Route("api/wines")]
public class WineController : ControllerBase
{
    private readonly IWineService _wineService;

    public WineController(IWineService wineService)
    {
        _wineService = wineService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var wines = _wineService.GetWines();

        return Ok(wines);
    }

    [HttpPost]
    public IActionResult Create([FromBody] WineForCreationDTO wineDTO)
    {
        _wineService.AddWine(wineDTO);

        return Ok("El vino ha sido agregado exitosamente.");
    }
}