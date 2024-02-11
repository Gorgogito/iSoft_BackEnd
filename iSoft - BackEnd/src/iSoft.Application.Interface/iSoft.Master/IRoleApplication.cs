using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.DTO.iSoft.Master.Response;
using iSoft.Cross.Common;

namespace iSoft.Application.Interface.iSoft.Master
{
    public interface IRoleApplication
  {

    #region Métodos Síncronos

    Response<bool> Insert(RequestDtoRole_Insert request);
    Response<bool> Update(RequestDtoRole_Update request);
    Response<bool> Delete(RequestDtoRole_Delete request);

    Response<ResponseDtoRole> GetById(RequestDtoRole_GetById request);
    Response<IEnumerable<ResponseDtoRole>> List();
    Response<IEnumerable<ResponseDtoRole>> ListWithPagination(RequestDtoRole_ListWithPagination request);

    #endregion

    #region Métodos Asíncronos

    Task<Response<bool>> InsertAsync(RequestDtoRole_Insert request);
    Task<Response<bool>> UpdateAsync(RequestDtoRole_Update request);
    Task<Response<bool>> DeleteAsync(RequestDtoRole_Delete request);

    Task<Response<ResponseDtoRole>> GetByIdAsync(RequestDtoRole_GetById request);
    Task<Response<IEnumerable<ResponseDtoRole>>> ListAsync();
    Task<Response<IEnumerable<ResponseDtoRole>>> ListWithPaginationAsync(RequestDtoRole_ListWithPagination request);

    #endregion

  }
}
