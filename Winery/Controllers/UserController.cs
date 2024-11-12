using Common.Services;
using Data.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace Winery.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var users = _userService.GetUsers();

        return Ok(users);
    }

    [HttpPost]
    public IActionResult Create([FromBody] UserForCreationDTO userDTO)
    {
        _userService.AddUser(userDTO);

        return Ok("El usuario ha sido agregado exitosamente.");
    }
}
