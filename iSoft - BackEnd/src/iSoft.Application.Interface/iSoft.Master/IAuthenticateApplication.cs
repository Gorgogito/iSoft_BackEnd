using iSoft.Application.DTO.iSoft.Master.Response;
using iSoft.Cross.Common;

namespace iSoft.Application.Interface.iSoft.Master
{
    public interface IAuthenticateApplication
  {

    Response<ResponseDtoAuthenticate> Authenticate(string username, string password);

  }
}
