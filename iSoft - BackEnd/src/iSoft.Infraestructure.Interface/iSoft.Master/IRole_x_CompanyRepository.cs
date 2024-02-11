using iSoft.Domain.Entity.iSoft.Master.identy;

namespace iSoft.Infrastructure.Interface.iSoft.Master
{
  public interface IRole_x_CompanyRepository
  {

    #region Métodos Síncronos

    bool Insert(Role_x_Company entity);
    bool Update(Role_x_Company entity);
    bool Delete(string roleId, string companyId);

    Role_x_Company GetById(string roleId, string companyId);
    IEnumerable<Role_x_Company> List();
    IEnumerable<Role_x_Company> ListWithPagination(int pageNumber, int pageSize);

    #endregion

    #region Métodos Asíncronos

    Task<bool> InsertAsync(Role_x_Company entity);
    Task<bool> UpdateAsync(Role_x_Company entity);
    Task<bool> DeleteAsync(string roleId, string companyId);

    Task<Role_x_Company> GetByIdAsync(string roleId, string companyId);
    Task<IEnumerable<Role_x_Company>> ListAsync();
    Task<IEnumerable<Role_x_Company>> ListWithPaginationAsync(int pageNumber, int pageSize);

    #endregion

  }
}
