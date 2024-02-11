using iSoft.Domain.Entity.iSoft.Master.identy;

namespace iSoft.Infrastructure.Interface.iSoft.Master
{
  public interface IUserRepository
  {

    #region Métodos Síncronos

    bool Insert(User entity);
    bool Update(User entity);
    bool Delete(string keyId);

    User GetByID(string keyId);
    IEnumerable<User> List();
    IEnumerable<User> ListWithPagination(int pageNumber, int pageSize);

    #endregion

    #region Métodos Asíncronos

    Task<bool> InsertAsync(User entity);
    Task<bool> UpdateAsync(User entity);
    Task<bool> DeleteAsync(string keyId);

    Task<User> GetByIDAsync(string keyId);
    Task<IEnumerable<User>> ListAsync();
    Task<IEnumerable<User>> ListWithPaginationAsync(int pageNumber, int pageSize);

    #endregion

  }
}
