using Dapper;
using iSoft.Cross.Common;
using iSoft.Domain.Entity.iSoft.Master.identy;
using iSoft.Infrastructure.Interface.iSoft.Master;
using System.Data;
using static Dapper.SqlMapper;

namespace iSoft.Infrastructure.Repository.iSoft.Master
{
  public class UserRepository : IUserRepository
  {

    private readonly IConnectionFactory _connectionFactory;

    public UserRepository(IConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    #region Métodos Síncronos        

    public bool Insert(User entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[UserInsert]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("UserName", entity.UserName);
        parameters.Add("Password", entity.Password);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Names", entity.Names);
        parameters.Add("Surnames", entity.Surnames);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Image", entity.Image);
        parameters.Add("RoleId", entity.RoleId);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("CreatedDate", entity.CreatedDate);
        parameters.Add("CreatedBy", entity.CreatedBy);

        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public bool Update(User entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[UserUpdate]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("UserName", entity.UserName);
        parameters.Add("Password", entity.Password);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Names", entity.Names);
        parameters.Add("Surnames", entity.Surnames);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Image", entity.Image);
        parameters.Add("RoleId", entity.RoleId);
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
        var query = "[identy].[UserDelete]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);
        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public User GetByID(string keyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        User entity = null;
        var query = "SELECT count(*) from [identy].[User] WHERE KeyId = @KeyId";

        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);

        var exist = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.Text);

        query = "[identy].[UserGetByID]";

        if (exist > 0)
        { entity = connection.QuerySingle<User>(query, param: parameters, commandType: CommandType.StoredProcedure); }

        return entity;
      }
    }

    public IEnumerable<User> List()
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[UserList]";

        var entity = connection.Query<User>(query, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public IEnumerable<User> ListWithPagination(int pageNumber, int pageSize)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[UserListWithPagination]";
        var parameters = new DynamicParameters();
        parameters.Add("PageNumber", pageNumber);
        parameters.Add("PageSize", pageSize);

        var entity = connection.Query<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> InsertAsync(User entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[UserInsert]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("UserName", entity.UserName);
        parameters.Add("Password", entity.Password);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Names", entity.Names);
        parameters.Add("Surnames", entity.Surnames);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Image", entity.Image);
        parameters.Add("RoleId", entity.RoleId);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("CreatedDate", entity.CreatedDate);
        parameters.Add("CreatedBy", entity.CreatedBy);

        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<bool> UpdateAsync(User entity)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[UserUpdate]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("UserName", entity.UserName);
        parameters.Add("Password", entity.Password);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Names", entity.Names);
        parameters.Add("Surnames", entity.Surnames);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Image", entity.Image);
        parameters.Add("RoleId", entity.RoleId);
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
        var query = "[identy].[UserDelete]";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);
        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<User> GetByIDAsync(string keyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        User entity = null;
        var query = "SELECT count(*) from [identy].[User] WHERE KeyId = @KeyId";

        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);

        var exist = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.Text);

        query = "[identy].[UserGetByID]";

        if (exist > 0)
        { entity = await connection.QuerySingleAsync<User>(query, param: parameters, commandType: CommandType.StoredProcedure); }

        return entity;
      }
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[UserList]";

        var entity = await connection.QueryAsync<User>(query, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public async Task<IEnumerable<User>> ListWithPaginationAsync(int pageNumber, int pageSize)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[identy].[UserListWithPagination]";
        var parameters = new DynamicParameters();
        parameters.Add("PageNumber", pageNumber);
        parameters.Add("PageSize", pageSize);

        var entity = await connection.QueryAsync<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    #endregion

  }
}
