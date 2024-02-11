using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.DTO.iSoft.Master.Response;
using iSoft.Cross.Common;

namespace iSoft.Application.Interface.iSoft.Master
{
  public interface ICompanyApplication
  {

    #region Métodos Síncronos

    Response<bool> Insert(RequestDtoCompany_Insert request);
    Response<bool> Update(RequestDtoCompany_Update request);
    Response<bool> Delete(RequestDtoCompany_Delete request);

    Response<ResponseDtoCompany> GetById(RequestDtoCompany_GetById request);
    Response<IEnumerable<ResponseDtoCompany>> List();
    Response<IEnumerable<ResponseDtoCompany>> ListWithPagination(RequestDtoCompany_ListWithPagination request);

    #endregion

    #region Métodos Asíncronos

    Task<Response<bool>> InsertAsync(RequestDtoCompany_Insert request);
    Task<Response<bool>> UpdateAsync(RequestDtoCompany_Update request);
    Task<Response<bool>> DeleteAsync(RequestDtoCompany_Delete request);

    Task<Response<ResponseDtoCompany>> GetByIdAsync(RequestDtoCompany_GetById request);
    Task<Response<IEnumerable<ResponseDtoCompany>>> ListAsync();
    Task<Response<IEnumerable<ResponseDtoCompany>>> ListWithPaginationAsync(RequestDtoCompany_ListWithPagination request);

    #endregion

  }
}
