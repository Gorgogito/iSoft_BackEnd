using iSoft.Domain.Entity.iSoft.Master.master;

namespace iSoft.Domain.Interface.iSoft.Master
{
  public interface ICompanyDomain //: ICommonDomain
  {

    #region Métodos Síncronos

    bool Insert(Company entity);
    bool Update(Company entity);
    bool Delete(string keyId);

    Company GetById(string keyId);
    IEnumerable<Company> List();
    IEnumerable<Company> ListWithPagination(int pageNumber, int pageSize);

    #endregion

    #region Métodos Asíncronos

    Task<bool> InsertAsync(Company entity);
    Task<bool> UpdateAsync(Company entity);
    Task<bool> DeleteAsync(string keyId);

    Task<Company> GetByIdAsync(string keyId);
    Task<IEnumerable<Company>> ListAsync();
    Task<IEnumerable<Company>> ListWithPaginationAsync(int pageNumber, int pageSize);

    #endregion

  }
}
