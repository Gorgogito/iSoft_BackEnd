using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.DTO.iSoft.Master.Response;
using iSoft.Cross.Common;

namespace iSoft.Application.Interface.iSoft.Master
{
  public interface IRole_x_CompanyApplication
  {

    #region Métodos Síncronos

    Response<bool> Insert(RequestDtoRole_x_Company_Insert request);
    Response<bool> Update(RequestDtoRole_x_Company_Update request);
    Response<bool> Delete(RequestDtoRole_x_Company_Delete request);

    Response<ResponseDtoRole_x_Company> GetById(RequestDtoRole_x_Company_GetById request);
    Response<IEnumerable<ResponseDtoRole_x_Company>> List();
    Response<IEnumerable<ResponseDtoRole_x_Company>> ListWithPagination(RequestDtoRole_x_Company_ListWithPagination request);

    #endregion

    #region Métodos Asíncronos

    Task<Response<bool>> InsertAsync(RequestDtoRole_x_Company_Insert request);
    Task<Response<bool>> UpdateAsync(RequestDtoRole_x_Company_Update request);
    Task<Response<bool>> DeleteAsync(RequestDtoRole_x_Company_Delete request);

    Task<Response<ResponseDtoRole_x_Company>> GetByIdAsync(RequestDtoRole_x_Company_GetById request);
    Task<Response<IEnumerable<ResponseDtoRole_x_Company>>> ListAsync();
    Task<Response<IEnumerable<ResponseDtoRole_x_Company>>> ListWithPaginationAsync(RequestDtoRole_x_Company_ListWithPagination request);

    #endregion

  }
}
