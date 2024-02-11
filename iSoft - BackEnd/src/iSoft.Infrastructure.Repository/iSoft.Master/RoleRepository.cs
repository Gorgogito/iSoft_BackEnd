using Dapper;
using iSoft.Cross.Common;
using iSoft.Domain.Entity.iSoft.Master.identy;
using iSoft.Infrastructure.Interface.iSoft.Master;
using System.Data;

namespace iSoft.Infrastructure.Repository.iSoft.Master
{
  public class RoleRepository : IRoleRepository
  {

    private readonly IConnectionFactory _connectionFactory;

    public RoleRepository(IConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    #region Métodos Síncronos        

    public bool Insert(Role entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[RoleInsert]";
        var parameters = new DynamicParameters();

        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Name", entity.Name);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("CreatedDate", entity.CreatedDate);
        parameters.Add("CreatedBy", entity.CreatedBy);

        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public bool Update(Role entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[RoleUpdate]";
        var parameters = new DynamicParameters();

        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Name", entity.Name);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
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
        var query = "[identy].[RoleDelete]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);
        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public Role GetById(string keyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        Role entity = null;
        var query = "SELECT count(*) from [identy].[Role] WHERE KeyId = @KeyId";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);

        var exist = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.Text);
        query = "[identy].[RoleGetByID]";

        if (exist > 0)
        { entity = connection.QuerySingle<Role>(query, param: parameters, commandType: CommandType.StoredProcedure); }
        return entity;
      }
    }

    public IEnumerable<Role> List()
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[RoleList]";

        var entity = connection.Query<Role>(query, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public IEnumerable<Role> ListWithPagination(int pageNumber, int pageSize)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[RoleListWithPagination]";
        var parameters = new DynamicParameters();
        parameters.Add("PageNumber", pageNumber);
        parameters.Add("PageSize", pageSize);

        var entity = connection.Query<Role>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> InsertAsync(Role entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[RoleInsert]";
        var parameters = new DynamicParameters();

        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Name", entity.Name);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("CreatedDate", entity.CreatedDate);
        parameters.Add("CreatedBy", entity.CreatedBy);

        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<bool> UpdateAsync(Role entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[RoleUpdate]";
        var parameters = new DynamicParameters();

        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Name", entity.Name);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
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
        var query = "[identy].[RoleDelete]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);
        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<Role> GetByIdAsync(string keyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        Role entity = null;
        var query = "SELECT count(*) from [identy].[Role] WHERE KeyId = @KeyId";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);

        var exist = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.Text);

        query = "[identy].[RoleGetByID]";

        if (exist > 0)
        { entity = await connection.QuerySingleAsync<Role>(query, param: parameters, commandType: CommandType.StoredProcedure); }

        return entity;
      }
    }

    public async Task<IEnumerable<Role>> ListAsync()
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[RoleList]";

        var entity = await connection.QueryAsync<Role>(query, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public async Task<IEnumerable<Role>> ListWithPaginationAsync(int pageNumber, int pageSize)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[RoleListWithPagination]";
        var parameters = new DynamicParameters();
        parameters.Add("PageNumber", pageNumber);
        parameters.Add("PageSize", pageSize);

        var entity = await connection.QueryAsync<Role>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    #endregion

  }
}
