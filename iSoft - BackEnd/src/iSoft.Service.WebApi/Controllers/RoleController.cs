using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.Interface.iSoft.Master;
using Microsoft.AspNetCore.Mvc;

namespace iSoft.Service.WebApi.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class RoleController : Controller
  {
    private readonly IRoleApplication _entityApplication;

    public RoleController(IRoleApplication entityApplication)
    {
      _entityApplication = entityApplication;
    }

    #region "Métodos Sincronos"

    [HttpPost("Insert")]
    public IActionResult Insert([FromBody] RequestDtoRole_Insert requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = _entityApplication.Insert(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] RequestDtoRole_Update requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = _entityApplication.Update(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpDelete("Delete")]
    public IActionResult Delete([FromBody] RequestDtoRole_Delete requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = _entityApplication.Delete(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpPatch("GetByID")]
    public IActionResult GetByID([FromBody] RequestDtoRole_GetById requestDto)
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

      return BadRequest(response.Message);
    }

    [HttpPatch("WithPagination")]
    public IActionResult WithPagination([FromBody] RequestDtoRole_ListWithPagination requestDto)
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
    public async Task<IActionResult> InsertAsync([FromBody] RequestDtoRole_Insert requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = await _entityApplication.InsertAsync(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync([FromBody] RequestDtoRole_Update requestDto)
    {
      if (requestDto == null)
        return BadRequest();
      var response = await _entityApplication.UpdateAsync(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpDelete("DeleteAsync")]
    public async Task<IActionResult> DeleteAsync([FromBody] RequestDtoRole_Delete requestDto)
    {
      if (requestDto==null)
        return BadRequest();
      var response = await _entityApplication.DeleteAsync(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    [HttpPatch("GetByIDAsync")]
    public async Task<IActionResult> GetAsync([FromBody] RequestDtoRole_GetById requestDto)
    {
      if (requestDto==null)
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

      return BadRequest(response.Message);
    }

    [HttpPatch("WithPaginationAsync")]
    public async Task<IActionResult> WithPaginationAsync([FromBody] RequestDtoRole_ListWithPagination requestDto)
    {
      if (requestDto==null)
        return BadRequest();
      var response = await _entityApplication.ListWithPaginationAsync(requestDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response);
    }

    #endregion

  }
}
