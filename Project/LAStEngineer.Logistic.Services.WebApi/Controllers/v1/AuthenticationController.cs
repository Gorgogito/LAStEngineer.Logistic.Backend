using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Application.Interface.UseCases.Main;
using LAStEngineer.Logistic.Cross.Common;
using LAStEngineer.Logistic.Services.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LAStEngineer.Logistic.Services.WebApi.Controllers.v1
{

    [Authorize]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [ApiVersion("1.0", Deprecated = false)]
  public class AuthenticationController : Controller
  {

    private readonly IAuthenticationApplication _authenticationApplication;
    private readonly AppSettings _appSettings;

    public AuthenticationController(IAuthenticationApplication authApplication, IOptions<AppSettings> appSettings)
    {
      _authenticationApplication = authApplication;
      _appSettings = appSettings.Value;
    }

    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public IActionResult Authenticate([FromQuery] string userName, [FromQuery] string password)
    {
      var response = _authenticationApplication.Authenticate(userName, password);
      if (response.IsSuccess)
      {
        if (response.Data != null)
        {
          response.Data.Token = BuildToken(response);
          return Ok(response);
        }
        else
          return NotFound(response);
      }

      return BadRequest(response);
    }

    private string BuildToken(Response<UserDTO> usersDto)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, usersDto.Data.KeyId.ToString())
        }),
        Expires = DateTime.UtcNow.AddMinutes(30),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        Issuer = _appSettings.Issuer,
        Audience = _appSettings.Audience
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var tokenString = tokenHandler.WriteToken(token);
      return tokenString;
    }
  }
}
