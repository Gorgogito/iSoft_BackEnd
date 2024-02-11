using Dapper;
using iSoft.Cross.Common;
using iSoft.Domain.Entity.iSoft.Master.master;
using iSoft.Infrastructure.Interface.iSoft.Master;
using System.Data;

namespace iSoft.Infrastructure.Repository.iSoft.Master
{
  public class StatusRepository : IStatusRepository
  {

    private readonly IConnectionFactory _connectionFactory;

    public StatusRepository(IConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    #region Métodos Síncronos        

    public Status GetByID(string keyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        Status entity = null;
        var query = "SELECT count(*) from [master].[Status] WHERE KeyId = @KeyId";

        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);
        var exist = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.Text);
        query = "[master].[StatusGetByID]";

        if (exist > 0)
        { entity = connection.QuerySingle<Status>(query, param: parameters, commandType: CommandType.StoredProcedure); }

        return entity;
      }
    }

    public IEnumerable<Status> List()
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[master].[StatusList]";

        var list = connection.Query<Status>(query, commandType: CommandType.StoredProcedure);
        return list;
      }
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<Status> GetByIDAsync(string keyId)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        Status entity = null;
        var query = "SELECT count(*) from [master].[Status] WHERE KeyId = @KeyId";
        
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", keyId);
        var exist = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.Text);
        query = "[master].[StatusGetByID]";

        if (exist > 0)
        { entity = await connection.QuerySingleAsync<Status>(query, param: parameters, commandType: CommandType.StoredProcedure); }

        return entity;
      }
    }

    public async Task<IEnumerable<Status>> ListAsync()
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var query = "[master].[StatusList]";

        var list = await connection.QueryAsync<Status>(query, commandType: CommandType.StoredProcedure);
        return list;
      }
    }

    #endregion

  }
}
