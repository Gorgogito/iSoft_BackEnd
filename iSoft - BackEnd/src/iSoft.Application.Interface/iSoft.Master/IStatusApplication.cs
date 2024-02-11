using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.DTO.iSoft.Master.Response;
using iSoft.Cross.Common;

namespace iSoft.Application.Interface.iSoft.Master
{
    public interface IStatusApplication
  {

    #region Métodos Síncronos

    Response<ResponseDtoStatus> GetByID(RequestDtoStatus_GetById request);
    Response<IEnumerable<ResponseDtoStatus>> List();

    #endregion

    #region Métodos Asíncronos

    Task<Response<ResponseDtoStatus>> GetByIDAsync(RequestDtoStatus_GetById request);
    Task<Response<IEnumerable<ResponseDtoStatus>>> ListAsync();

    #endregion

  }
}
