using iSoft.Domain.Entity.iSoft.Master.identy;

namespace iSoft.Domain.Interface.iSoft.Master
{
  public interface IAuthenticateDomain
  {

    Authenticate Authenticate(string username, string password);

  }
}
