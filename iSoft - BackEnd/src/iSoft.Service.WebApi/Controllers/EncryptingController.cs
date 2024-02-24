using iSoft.Application.Interface.iSoft.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iSoft.Service.WebApi.Controllers
{

  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class EncryptingController : Controller
  {

    private readonly IEncryptingApplication _entityApplication;

    public EncryptingController(IEncryptingApplication entityApplication)
    {
      _entityApplication = entityApplication;
    }

    #region "Métodos Sincronos"

    [AllowAnonymous]
    [HttpPatch("EncryptString")]
    public IActionResult EncryptString([FromBody] string requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = _entityApplication.EncryptString(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [AllowAnonymous]
    [HttpPatch("DecryptString")]
    public IActionResult DecryptString([FromBody] string requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = _entityApplication.DecryptString(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    #endregion

    #region "Métodos Asincronos"

    [AllowAnonymous]
    [HttpPatch("EncryptStringAsync")]
    public async Task<IActionResult> EncryptStringAsync([FromBody] string requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = await _entityApplication.EncryptStringAsync(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [AllowAnonymous]
    [HttpPatch("ListAsync")]
    public async Task<IActionResult> DecryptStringAsync([FromBody] string requestDto)
    {
      var response = await _entityApplication.DecryptStringAsync(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    #endregion


  }
}
