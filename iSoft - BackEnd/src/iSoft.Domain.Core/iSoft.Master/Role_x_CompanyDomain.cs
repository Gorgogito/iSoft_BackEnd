using iSoft.Domain.Interface.iSoft.Master;
using iSoft.Domain.Entity.iSoft.Master.identy;
using iSoft.Infrastructure.Interface.iSoft.Master;

namespace iSoft.Domain.Core.iSoft.Master
{
  public class Role_x_CompanyDomain: IRole_x_CompanyDomain
  {

    private readonly IRole_x_CompanyRepository _repository;

    public Role_x_CompanyDomain(IRole_x_CompanyRepository repository)
    {
      _repository = repository;
    }

    #region Métodos Síncronos

    public bool Insert(Role_x_Company entity)
    {
      return _repository.Insert(entity);
    }

    public bool Update(Role_x_Company entity)
    {
      return _repository.Update(entity);
    }

    public bool Delete(string roleId, string companyId)
    {
      return _repository.Delete(roleId, companyId);
    }

    public Role_x_Company GetById(string roleId, string companyId)
    {
      return _repository.GetById(roleId, companyId);
    }

    public IEnumerable<Role_x_Company> List()
    {
      return _repository.List();
    }

    public IEnumerable<Role_x_Company> ListWithPagination(int pageNumber, int pageSize)
    {
      return _repository.ListWithPagination(pageNumber, pageSize);
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> InsertAsync(Role_x_Company entity)
    {
      return await _repository.InsertAsync(entity);
    }

    public async Task<bool> UpdateAsync(Role_x_Company entity)
    {
      return await _repository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(string roleId, string companyId)
    {
      return await _repository.DeleteAsync(roleId, companyId);
    }

    public async Task<Role_x_Company> GetByIdAsync(string roleId, string companyId)
    {
      return await _repository.GetByIdAsync(roleId, companyId);
    }

    public async Task<IEnumerable<Role_x_Company>> ListAsync()
    {
      return await _repository.ListAsync();
    }

    public async Task<IEnumerable<Role_x_Company>> ListWithPaginationAsync(int pageNumber, int pageSize)
    {
      return await _repository.ListWithPaginationAsync(pageNumber, pageSize);
    }

    #endregion

  }
}
