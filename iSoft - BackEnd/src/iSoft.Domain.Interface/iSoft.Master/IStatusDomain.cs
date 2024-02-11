using iSoft.Domain.Entity.iSoft.Master.master;

namespace iSoft.Domain.Interface.iSoft.Master
{
  public interface IStatusDomain
  {

    #region Métodos Síncronos

    Status GetByID(string keyId);
    IEnumerable<Status> List();

    #endregion

    #region Métodos Asíncronos

    Task<Status> GetByIDAsync(string keyId);
    Task<IEnumerable<Status>> ListAsync();

    #endregion

  }
}
