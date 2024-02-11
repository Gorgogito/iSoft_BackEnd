using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.Interface.iSoft.Master;
using Microsoft.AspNetCore.Mvc;

namespace iSoft.Service.WebApi.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class StatusController : Controller
  {

    private readonly IStatusApplication _entityApplication;

    public StatusController(IStatusApplication customersApplication)
    {
      _entityApplication = customersApplication;
    }

    #region "Métodos Sincronos"

    [HttpPatch("GetByID")]
    public IActionResult GetByID([FromBody] RequestDtoStatus_GetById requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = _entityApplication.GetByID(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpGet("List")]
    public IActionResult List()
    {
      var response = _entityApplication.List();
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    #endregion

    #region "Métodos Asincronos"

    [HttpPatch("GetByIDAsync")]
    public async Task<IActionResult> GetAsync([FromBody] RequestDtoStatus_GetById requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = await _entityApplication.GetByIDAsync(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpGet("ListAsync")]
    public async Task<IActionResult> ListAsync()
    {
      var response = await _entityApplication.ListAsync();
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    #endregion

  }
}
