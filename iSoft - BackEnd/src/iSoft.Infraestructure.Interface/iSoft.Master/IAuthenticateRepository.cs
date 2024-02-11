using iSoft.Domain.Entity.iSoft.Master.identy;

namespace iSoft.Infrastructure.Interface.iSoft.Master
{
  public interface IAuthenticateRepository
  {

    Authenticate Authenticate(string username, string password);

  }
}
