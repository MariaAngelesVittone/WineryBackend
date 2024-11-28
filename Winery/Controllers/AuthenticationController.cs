using Data.DTO_s;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Winery.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepository;

    public AuthenticationController(IConfiguration config, IUserRepository userRepository)
    {
        _config = config;
        this._userRepository = userRepository;

    }

    [HttpPost]
    [Route("Authenticate")]
    public IActionResult Auth(CredentialsDTO credentialsDTO)
    {
        var user = _userRepository.ValidateUser(credentialsDTO);

        if (user is null)
        {
            return Forbid();
        }

        var claims = new List<Claim>
    {
        new Claim("id", user.Id.ToString()),
        new Claim("username", user.Username),
    };

        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
                   _config["Jwt:Issuer"],
                   _config["Jwt:Audience"],
                   claims,
                   DateTime.UtcNow,
                   DateTime.UtcNow.AddHours(1),
                   credentials);

        var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
            .WriteToken(jwtSecurityToken);


        return Ok(tokenToReturn);
    }
}