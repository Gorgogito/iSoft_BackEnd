using Dapper;
using iSoft.Cross.Common;
using iSoft.Domain.Entity.iSoft.Master.master;
using iSoft.Infrastructure.Interface.iSoft.Master;
using System.Data;

namespace iSoft.Infrastructure.Repository.iSoft.Master
{
  public class CompanyRepository : ICompanyRepository
  {

    private readonly IConnectionFactory _connectionFactory;

    public CompanyRepository(IConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    #region Métodos Síncronos        

    public bool Insert(Company entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {

        var query = "[master].[CompanyInsert]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Ruc", entity.Ruc);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Address", entity.Address);
        parameters.Add("Agent", entity.Agent);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Web", entity.Web);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("CreatedDate", entity.CreatedDate);
        parameters.Add("CreatedBy", entity.CreatedBy);

        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public bool Update(Company entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[master].[CompanyUpdate]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Ruc", entity.Ruc);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Address", entity.Address);
        parameters.Add("Agent", entity.Agent);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Web", entity.Web);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("LastModifiedDate", entity.LastModifiedDate);
        parameters.Add("LastModifiedBy", entity.LastModifiedBy);

        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public bool Delete(string keyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[master].[CompanyDelete]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);
        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public Company GetByID(string keyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {

        Company entity = null;
        var query = "SELECT count(*) from [master].[Company] WHERE KeyId = @KeyId";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);

        var exist = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.Text);
        query = "[master].[CompanyGetByID]";

        if (exist > 0)
        { entity = connection.QuerySingle<Company>(query, param: parameters, commandType: CommandType.StoredProcedure); }
        return entity;

      }
    }

    public IEnumerable<Company> List()
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[master].[CompanyList]";

        var entity = connection.Query<Company>(query, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public IEnumerable<Company> ListWithPagination(int pageNumber, int pageSize)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[master].[CompanyListWithPagination]";
        var parameters = new DynamicParameters();
        parameters.Add("PageNumber", pageNumber);
        parameters.Add("PageSize", pageSize);

        var entity = connection.Query<Company>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> InsertAsync(Company entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[master].[CompanyInsert]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Ruc", entity.Ruc);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Address", entity.Address);
        parameters.Add("Agent", entity.Agent);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Web", entity.Web);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("CreatedDate", entity.CreatedDate);
        parameters.Add("CreatedBy", entity.CreatedBy);

        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<bool> UpdateAsync(Company entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[master].[CompanyUpdate]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Ruc", entity.Ruc);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Address", entity.Address);
        parameters.Add("Agent", entity.Agent);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Web", entity.Web);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("LastModifiedDate", entity.LastModifiedDate);
        parameters.Add("LastModifiedBy", entity.LastModifiedBy);

        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<bool> DeleteAsync(string keyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[master].[CompanyDelete]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);
        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<Company> GetByIDAsync(string keyId)
    {

      using (var connection = _connectionFactory.GetConnection)
      {
        Company entity = null;
        var query = "SELECT count(*) from [master].[Company] WHERE KeyId = @KeyId";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);

        var exist = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.Text);

        query = "[master].[CompanyGetByID]";

        if (exist > 0)
        { entity = await connection.QuerySingleAsync<Company>(query, param: parameters, commandType: CommandType.StoredProcedure); }

        return entity;
      }

    }

    public async Task<IEnumerable<Company>> ListAsync()
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[master].[CompanyList]";

        var entity = await connection.QueryAsync<Company>(query, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public async Task<IEnumerable<Company>> ListWithPaginationAsync(int pageNumber, int pageSize)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[master].[CompanyListWithPagination]";
        var parameters = new DynamicParameters();
        parameters.Add("PageNumber", pageNumber);
        parameters.Add("PageSize", pageSize);

        var entity = await connection.QueryAsync<Company>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    #endregion

  }
}
