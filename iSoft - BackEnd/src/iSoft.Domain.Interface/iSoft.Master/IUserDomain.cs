using iSoft.Domain.Entity;
using iSoft.Domain.Entity.iSoft.Master.identy;

namespace iSoft.Domain.Interface.iSoft.Master
{
  public interface IUserDomain //: ICommonDomain
  {

    #region Métodos Síncronos

    bool Insert(User entity);
    bool Update(User entity);
    bool Delete(string keyId);

    User GetById(string keyId);
    IEnumerable<User> ListWithPagination(int pageNumber, int pageSize);
    IEnumerable<User> List();

    #endregion

    #region Métodos Asíncronos

    Task<bool> InsertAsync(User entity);
    Task<bool> UpdateAsync(User entity);
    Task<bool> DeleteAsync(string keyId);

    Task<User> GetByIdAsync(string keyId);
    Task<IEnumerable<User>> ListWithPaginationAsync(int pageNumber, int pageSize);
    Task<IEnumerable<User>> ListAsync();

    #endregion

  }
}
