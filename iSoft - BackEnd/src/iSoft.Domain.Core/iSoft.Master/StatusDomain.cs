using iSoft.Domain.Entity.iSoft.Master.master;
using iSoft.Domain.Interface.iSoft.Master;
using iSoft.Infrastructure.Interface.iSoft.Master;

namespace iSoft.Domain.Core.iSoft.Master
{
  public class StatusDomain : IStatusDomain
  {

    private readonly IStatusRepository _statussRepository;

    public StatusDomain(IStatusRepository customersRepository)
    {
      _statussRepository = customersRepository;
    }

    #region Métodos Síncronos
        
    public Status GetByID(string keyId)
    {
      return _statussRepository.GetByID(keyId);
    }

    public IEnumerable<Status> List()
    {
      return _statussRepository.List();
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<Status> GetByIDAsync(string keyId)
    {
      return await _statussRepository.GetByIDAsync(keyId);
    }

    public async Task<IEnumerable<Status>> ListAsync()
    {
      return await _statussRepository.ListAsync();
    }

    #endregion

  }
}
