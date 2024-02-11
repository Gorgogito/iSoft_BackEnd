using iSoft.Domain.Entity.iSoft.Master.master;

namespace iSoft.Infrastructure.Interface.iSoft.Master
{
  public interface ICompanyRepository
  {

    #region Métodos Síncronos

    bool Insert(Company entity);
    bool Update(Company entity);
    bool Delete(string keyId);

    Company GetByID(string keyId);
    IEnumerable<Company> List();
    IEnumerable<Company> ListWithPagination(int pageNumber, int pageSize);

    #endregion

    #region Métodos Asíncronos

    Task<bool> InsertAsync(Company entity);
    Task<bool> UpdateAsync(Company entity);
    Task<bool> DeleteAsync(string keyId);

    Task<Company> GetByIDAsync(string keyId);
    Task<IEnumerable<Company>> ListAsync();
    Task<IEnumerable<Company>> ListWithPaginationAsync(int pageNumber, int pageSize);

    #endregion

  }
}
