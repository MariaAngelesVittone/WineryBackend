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

    [HttpPost("authenticate")]
    public ActionResult<string> Autenticar(CredentialsDTO credentialsDto)
    {
        var user = _userRepository.ValidateUser(credentialsDto);

        if (user is null)
            return Unauthorized();

        var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));

        var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>
        {
            new Claim("sub", user.Id.ToString()),
            new Claim("given_name", user.Name),
            new Claim("family_name", user.LastName)
        };

        var jwtSecurityToken = new JwtSecurityToken(
          _config["Authentication:Issuer"],
          _config["Authentication:Audience"],
          claimsForToken,
          DateTime.UtcNow,
          DateTime.UtcNow.AddHours(1),
          credentials);

        var tokenToReturn = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToken);

        return Ok(tokenToReturn);
    }
}