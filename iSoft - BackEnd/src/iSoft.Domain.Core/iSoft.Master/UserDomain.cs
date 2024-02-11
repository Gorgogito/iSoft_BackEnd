using iSoft.Domain.Entity.iSoft.Master.identy;
using iSoft.Domain.Interface.iSoft.Master;
using iSoft.Infrastructure.Interface.iSoft.Master;

namespace iSoft.Domain.Core.iSoft.Master
{
  public class UserDomain : IUserDomain
  {

    private readonly IUserRepository _usersRepository;

    public UserDomain(IUserRepository usersRepository)
    {
      _usersRepository = usersRepository;
    }

    #region Métodos Síncronos

    public bool Insert(User entity)
    {
      return _usersRepository.Insert(entity);
    }

    public bool Update(User entity)
    {
      return _usersRepository.Update(entity);
    }

    public bool Delete(string keyId)
    {
      return _usersRepository.Delete(keyId);
    }
    public User GetById(string keyId)
    {
      return _usersRepository.GetByID(keyId);
    }

    public IEnumerable<User> List()
    {
      return _usersRepository.List();
    }

    public IEnumerable<User> ListWithPagination(int pageNumber, int pageSize)
    {
      return _usersRepository.ListWithPagination(pageNumber, pageSize);
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> InsertAsync(User entity)
    {
      return await _usersRepository.InsertAsync(entity);
    }

    public async Task<bool> UpdateAsync(User entity)
    {
      return await _usersRepository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(string keyId)
    {
      return await _usersRepository.DeleteAsync(keyId);
    }

    public async Task<User> GetByIdAsync(string keyId)
    {
      return await _usersRepository.GetByIDAsync(keyId);
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
      return await _usersRepository.ListAsync();
    }

    public async Task<IEnumerable<User>> ListWithPaginationAsync(int pageNumber, int pageSize)
    {
      return await _usersRepository.ListWithPaginationAsync(pageNumber, pageSize);
    }

    #endregion

  }
}
