using iSoft.Domain.Entity.iSoft.Master.master;
using iSoft.Domain.Interface.iSoft.Master;
using iSoft.Infrastructure.Interface.iSoft.Master;

namespace iSoft.Domain.Core.iSoft.Master
{
  public class CompanyDomain: ICompanyDomain
  {

    private readonly ICompanyRepository _repository;

    public CompanyDomain(ICompanyRepository repository)
    {
      _repository = repository;
    }

    #region Métodos Síncronos

    public bool Insert(Company entity)
    {
      return _repository.Insert(entity);
    }

    public bool Update(Company entity)
    {
      return _repository.Update(entity);
    }

    public bool Delete(string keyId)
    {
      return _repository.Delete(keyId);
    }

    public Company GetById(string keyId)
    {
      return _repository.GetByID(keyId);
    }

    public IEnumerable<Company> List()
    {
      return _repository.List();
    }

    public IEnumerable<Company> ListWithPagination(int pageNumber, int pageSize)
    {
      return _repository.ListWithPagination(pageNumber, pageSize);
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> InsertAsync(Company entity)
    {
      return await _repository.InsertAsync(entity);
    }

    public async Task<bool> UpdateAsync(Company entity)
    {
      return await _repository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(string keyId)
    {
      return await _repository.DeleteAsync(keyId);
    }

    public async Task<Company> GetByIdAsync(string keyId)
    {
      return await _repository.GetByIDAsync(keyId);
    }

    public async Task<IEnumerable<Company>> ListAsync()
    {
      return await _repository.ListAsync();
    }

    public async Task<IEnumerable<Company>> ListWithPaginationAsync(int pageNumber, int pageSize)
    {
      return await _repository.ListWithPaginationAsync(pageNumber, pageSize);
    }

    #endregion

  }
}
