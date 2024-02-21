using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.Interface.iSoft.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iSoft.Service.WebApi.Controllers
{

  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : Controller
  {

    private readonly IUserApplication _entityApplication;

    public UserController(IUserApplication entityApplication)
    {
      _entityApplication = entityApplication;
    }


    #region "Métodos Sincronos"

    [HttpPost("Insert")]
    public IActionResult Insert([FromBody] RequestDtoUser_Insert requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = _entityApplication.Insert(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] RequestDtoUser_Update requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = _entityApplication.Update(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpDelete("Delete")]
    public IActionResult Delete([FromBody] RequestDtoUser_Delete requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = _entityApplication.Delete(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpPatch("GetByID")]
    public IActionResult GetByID([FromBody] RequestDtoUser_GetById requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = _entityApplication.GetById(requestDto);
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

      return BadRequest(response);
    }

    [HttpPatch("WithPagination")]
    public IActionResult WithPagination([FromBody] RequestDtoUser_ListWithPagination requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = _entityApplication.ListWithPagination(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    #endregion

    #region "Métodos Asincronos"

    [HttpPost("InsertAsync")]
    public async Task<IActionResult> InsertAsync([FromBody] RequestDtoUser_Insert requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = await _entityApplication.InsertAsync(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync([FromBody] RequestDtoUser_Update requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = await _entityApplication.UpdateAsync(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpDelete("DeleteAsync")]
    public async Task<IActionResult> DeleteAsync([FromBody] RequestDtoUser_Delete requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = await _entityApplication.DeleteAsync(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpPatch("GetByIDAsync")]
    public async Task<IActionResult> GetAsync([FromBody] RequestDtoUser_GetById requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = await _entityApplication.GetByIdAsync(requestDto);
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

      return BadRequest(response);
    }

    [HttpPatch("WithPaginationAsync")]
    public async Task<IActionResult> WithPaginationAsync([FromBody] RequestDtoUser_ListWithPagination requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = await _entityApplication.ListWithPaginationAsync(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    #endregion

  }

}
