using iSoft.Domain.Entity.iSoft.Master.identy;
using iSoft.Domain.Interface.iSoft.Master;
using iSoft.Infrastructure.Interface.iSoft.Master;

namespace iSoft.Domain.Core.iSoft.Master
{
  public class RoleDomain: IRoleDomain
  {

    private readonly IRoleRepository _roleRepository;

    public RoleDomain(IRoleRepository roleRepository)
    {
      _roleRepository = roleRepository;
    }

    #region Métodos Síncronos

    public bool Insert(Role entity)
    {
      return _roleRepository.Insert(entity);
    }

    public bool Update(Role entity)
    {
      return _roleRepository.Update(entity);
    }

    public bool Delete(string keyId)
    {
      return _roleRepository.Delete(keyId);
    }
    public Role GetById(string keyId)
    {
      return _roleRepository.GetById(keyId);
    }

    public IEnumerable<Role> List()
    {
      return _roleRepository.List();
    }

    public IEnumerable<Role> ListWithPagination(int pageNumber, int pageSize)
    {
      return _roleRepository.ListWithPagination(pageNumber, pageSize);
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> InsertAsync(Role entity)
    {
      return await _roleRepository.InsertAsync(entity);
    }

    public async Task<bool> UpdateAsync(Role entity)
    {
      return await _roleRepository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(string keyId)
    {
      return await _roleRepository.DeleteAsync(keyId);
    }

    public async Task<Role> GetByIdAsync(string keyId)
    {
      return await _roleRepository.GetByIdAsync(keyId);
    }

    public async Task<IEnumerable<Role>> ListAsync()
    {
      return await _roleRepository.ListAsync();
    }

    public async Task<IEnumerable<Role>> ListWithPaginationAsync(int pageNumber, int pageSize)
    {
      return await _roleRepository.ListWithPaginationAsync(pageNumber, pageSize);
    }

    #endregion

  }
}
