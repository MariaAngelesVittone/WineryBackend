using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Common.Services;
using Data.DTO_s;

namespace Winery.Controllers;

[ApiController]
[Route("api/wines")]
[Authorize]
public class WineController : ControllerBase
{
    private readonly IWineService _wineService;

    public WineController(IWineService wineService)
    {
        _wineService = wineService;
    }

    [HttpGet("variety/{variety}")]
    public IActionResult Get(string variety)
    {
        var wines = _wineService.GetWinesByVariety(variety);

        return Ok(wines);
    }

    [HttpGet]
    public IActionResult GetByVariety()
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

    [HttpPut("stock/{id}")]
    public IActionResult UpdateStock(int id, [FromQuery] int newStock)
    {
        _wineService.UpdateStockById(id, newStock);

        return Ok("Stock actualizado correctamente.");
    }
}