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
    public ActionResult<string> Auth(CredentialsDTO credentialsDTO)
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
        new Claim("fullname", $"{user.Name} {user.LastName}")
    };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(720),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        return Ok(new
        {
            AccessToken = jwt
        });
    }
}