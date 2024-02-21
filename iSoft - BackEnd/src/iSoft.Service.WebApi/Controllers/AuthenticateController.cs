using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.DTO.iSoft.Master.Response;
using iSoft.Application.Interface.iSoft.Master;
using iSoft.Cross.Common;
using iSoft.Service.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace iSoft.Service.WebApi.Controllers
{

  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class AuthenticateController : Controller
  {

    private readonly IAuthenticateApplication _authenticateApplication;
    private readonly AppSettings _appSettings;

    private string _minutes;

    //public AuthenticateController(IAuthenticateApplication authApplication, IOptions<AppSettings> appSettings)
    //{
    //  _authenticateApplication = authApplication;
    //  _appSettings = appSettings.Value;

    //}

    public AuthenticateController(IAuthenticateApplication authApplication, IConfiguration configuration)
    {
      var appSettingsSection = configuration.GetSection("Config");
      //services.Configure<AppSettings>(appSettingsSection);
      _minutes = appSettingsSection.GetSection("MinutesExpires").Value;
      // configure jwt authentication
      var appSettings = appSettingsSection.Get<AppSettings>();

      _authenticateApplication = authApplication;
      _appSettings = appSettings;

    }


    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public IActionResult Authenticate([FromBody] RequestDtoLogin loginDto)
    {
      var response = _authenticateApplication.Authenticate(loginDto.UserName, loginDto.Password);
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

    private string BuildToken(Response<ResponseDtoAuthenticate> authenticateDto)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          { new Claim(ClaimTypes.Name, authenticateDto.Data.KeyId) }),
        Expires = DateTime.UtcNow.AddMinutes(double.Parse(_minutes)),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        Issuer = _appSettings.Issuer,
        Audience = _appSettings.Audience
      };
      SecurityToken token;
      token = tokenHandler.CreateToken(tokenDescriptor);
      var tokenString = tokenHandler.WriteToken(token);
      return tokenString;
    }

  }
}
