using iSoft.Domain.Entity.iSoft.Master.identy;
using iSoft.Domain.Interface.iSoft.Master;
using iSoft.Infrastructure.Interface.iSoft.Master;

namespace iSoft.Domain.Core.iSoft.Master
{
  public class AuthenticateDomain: IAuthenticateDomain
  {

    private readonly IAuthenticateRepository _authenticateRepository;

    public AuthenticateDomain(IAuthenticateRepository authenticateRepository)
    {
      _authenticateRepository = authenticateRepository;
    }

    public Authenticate Authenticate(string userName, string password)
    {
      return _authenticateRepository.Authenticate(userName, password);
    }


  }
}
