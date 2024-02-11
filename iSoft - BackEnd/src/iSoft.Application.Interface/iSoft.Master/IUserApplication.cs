using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.DTO.iSoft.Master.Response;
using iSoft.Cross.Common;

namespace iSoft.Application.Interface.iSoft.Master
{
  public interface IUserApplication
  {

    #region Métodos Síncronos

    Response<bool> Insert(RequestDtoUser_Insert request);
    Response<bool> Update(RequestDtoUser_Update request);
    Response<bool> Delete(RequestDtoUser_Delete request);

    Response<ResponseDtoUser> GetById(RequestDtoUser_GetById request);
    Response<IEnumerable<ResponseDtoUser>> List();
    Response<IEnumerable<ResponseDtoUser>> ListWithPagination(RequestDtoUser_ListWithPagination request);

    #endregion

    #region Métodos Asíncronos

    Task<Response<bool>> InsertAsync(RequestDtoUser_Insert request);
    Task<Response<bool>> UpdateAsync(RequestDtoUser_Update request);
    Task<Response<bool>> DeleteAsync(RequestDtoUser_Delete request);

    Task<Response<ResponseDtoUser>> GetByIdAsync(RequestDtoUser_GetById request);
    Task<Response<IEnumerable<ResponseDtoUser>>> ListAsync();
    Task<Response<IEnumerable<ResponseDtoUser>>> ListWithPaginationAsync(RequestDtoUser_ListWithPagination request);

    #endregion

  }
}
