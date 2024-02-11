using iSoft.Domain.Entity.iSoft.Master.identy;

namespace iSoft.Infrastructure.Interface.iSoft.Master
{
  public interface IRoleRepository
  {

    #region Métodos Síncronos

    bool Insert(Role entity);
    bool Update(Role entity);
    bool Delete(string keyId);

    Role GetById(string keyId);
    IEnumerable<Role> List();
    IEnumerable<Role> ListWithPagination(int pageNumber, int pageSize);

    #endregion

    #region Métodos Asíncronos

    Task<bool> InsertAsync(Role entity);
    Task<bool> UpdateAsync(Role entity);
    Task<bool> DeleteAsync(string keyId);

    Task<Role> GetByIdAsync(string keyId);
    Task<IEnumerable<Role>> ListAsync();
    Task<IEnumerable<Role>> ListWithPaginationAsync(int pageNumber, int pageSize);

    #endregion

  }
}
