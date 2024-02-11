using iSoft.Domain.Entity.iSoft.Master.identy;

namespace iSoft.Domain.Interface.iSoft.Master
{
  public interface IRoleDomain //: ICommonDomain
  {

    #region Métodos Síncronos

    bool Insert(Role entity);
    bool Update(Role entity);
    bool Delete(string keyId);

    Role GetById(string keyId);
    IEnumerable<Role> ListWithPagination(int pageNumber, int pageSize);
    IEnumerable<Role> List();

    #endregion

    #region Métodos Asíncronos

    Task<bool> InsertAsync(Role entity);
    Task<bool> UpdateAsync(Role entity);
    Task<bool> DeleteAsync(string keyId);

    Task<Role> GetByIdAsync(string keyId);
    Task<IEnumerable<Role>> ListWithPaginationAsync(int pageNumber, int pageSize);
    Task<IEnumerable<Role>> ListAsync();

    #endregion

  }
}