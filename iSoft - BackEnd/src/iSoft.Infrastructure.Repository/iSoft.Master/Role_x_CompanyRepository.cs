using Dapper;
using System.Data;
using iSoft.Cross.Common;
using iSoft.Domain.Entity.iSoft.Master.identy;
using iSoft.Infrastructure.Interface.iSoft.Master;

namespace iSoft.Infrastructure.Repository.iSoft.Master
{
  public class Role_x_CompanyRepository : IRole_x_CompanyRepository
  {

    private readonly IConnectionFactory _connectionFactory;

    public Role_x_CompanyRepository(IConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    #region Métodos Síncronos        

    public bool Insert(Role_x_Company entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[Role_x_CompanyInsert]";
        var parameters = new DynamicParameters();

        parameters.Add("RoleId", entity.RoleId);
        parameters.Add("CompanyId", entity.CompanyId);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("CreatedDate", entity.CreatedDate);
        parameters.Add("CreatedBy", entity.CreatedBy);

        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public bool Update(Role_x_Company entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[Role_x_CompanyUpdate]";
        var parameters = new DynamicParameters();

        parameters.Add("RoleId", entity.RoleId);
        parameters.Add("CompanyId", entity.CompanyId);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("LastModifiedDate", entity.LastModifiedDate);
        parameters.Add("LastModifiedBy", entity.LastModifiedBy);

        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public bool Delete(string roleId, string companyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[Role_x_CompanyDelete]";
        var parameters = new DynamicParameters();
        parameters.Add("RoleId", roleId);
        parameters.Add("CompanyId", companyId);
        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public Role_x_Company GetById(string roleId, string companyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        Role_x_Company entity = null;
        var query = "SELECT count(*) from [identy].[Role_x_Company] WHERE RoleId = @RoleId AND CompanyId = @CompanyId";
        var parameters = new DynamicParameters();
        parameters.Add("RoleId", roleId);
        parameters.Add("CompanyId", companyId);

        var exist = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.Text);
        query = "[identy].[Role_x_CompanyGetByID]";

        if (exist > 0)
        { entity = connection.QuerySingle<Role_x_Company>(query, param: parameters, commandType: CommandType.StoredProcedure); }
        return entity;
      }
    }

    public IEnumerable<Role_x_Company> List()
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[Role_x_CompanyList]";

        var entity = connection.Query<Role_x_Company>(query, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public IEnumerable<Role_x_Company> ListWithPagination(int pageNumber, int pageSize)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[Role_x_CompanyListWithPagination]";
        var parameters = new DynamicParameters();
        parameters.Add("PageNumber", pageNumber);
        parameters.Add("PageSize", pageSize);

        var entity = connection.Query<Role_x_Company>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> InsertAsync(Role_x_Company entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[Role_x_CompanyInsert]";
        var parameters = new DynamicParameters();

        parameters.Add("RoleId", entity.RoleId);
        parameters.Add("CompanyId", entity.CompanyId);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("CreatedDate", entity.CreatedDate);
        parameters.Add("CreatedBy", entity.CreatedBy);

        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<bool> UpdateAsync(Role_x_Company entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[Role_x_CompanyUpdate]";
        var parameters = new DynamicParameters();

        parameters.Add("RoleId", entity.RoleId);
        parameters.Add("CompanyId", entity.CompanyId);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("LastModifiedDate", entity.LastModifiedDate);
        parameters.Add("LastModifiedBy", entity.LastModifiedBy);

        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<bool> DeleteAsync(string roleId, string companyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[Role_x_CompanyDelete]";
        var parameters = new DynamicParameters();
        parameters.Add("RoleId", roleId);
        parameters.Add("CompanyId", companyId);
        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<Role_x_Company> GetByIdAsync(string roleId, string companyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        Role_x_Company entity = null;
        var query = "SELECT count(*) from [identy].[Role_x_Company] WHERE RoleId = @RoleId AND CompanyId = @CompanyId";
        var parameters = new DynamicParameters();
        parameters.Add("RoleId", roleId);
        parameters.Add("CompanyId", companyId);

        var exist = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.Text);

        query = "[identy].[Role_x_CompanyGetByID]";

        if (exist > 0)
        { entity = await connection.QuerySingleAsync<Role_x_Company>(query, param: parameters, commandType: CommandType.StoredProcedure); }

        return entity;
      }
    }

    public async Task<IEnumerable<Role_x_Company>> ListAsync()
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[Role_x_CompanyList]";

        var entity = await connection.QueryAsync<Role_x_Company>(query, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public async Task<IEnumerable<Role_x_Company>> ListWithPaginationAsync(int pageNumber, int pageSize)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[Role_x_CompanyListWithPagination]";
        var parameters = new DynamicParameters();
        parameters.Add("PageNumber", pageNumber);
        parameters.Add("PageSize", pageSize);

        var entity = await connection.QueryAsync<Role_x_Company>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    #endregion

  }
}
