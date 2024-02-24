using Dapper;
using iSoft.Cross.Common;
using iSoft.Infrastructure.Interface.iSoft.Master;
using System.Data;

namespace iSoft.Infrastructure.Repository.iSoft.Master.Encrypting
{

  public class EncryptingRepository: IEncryptingRepository
  {

    private readonly IConnectionFactory _connectionFactory;

    public EncryptingRepository(IConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    #region Métodos Síncronos

    public string EncryptString(string stringValue)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var parameters = new DynamicParameters();
        parameters.Add("Text", stringValue);
        parameters.Add("Key", "@");
        var query = "SELECT [process].[EncryptString](@Text, @Key)";
        var result = connection.QuerySingle<String>(sql: query, param: parameters, commandType: CommandType.Text);

        return result;
      }
    }

    public string DecryptString(string stringValue)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var parameters = new DynamicParameters();
        parameters.Add("Text", stringValue);
        parameters.Add("Key", "@");
        var query = "SELECT [process].[DecryptString](@Text, @Key)";
        var result = connection.QuerySingle<String>(sql: query, param: parameters, commandType: CommandType.Text);

        return result;
      }
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<string> EncryptStringAsync(string stringValue)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var parameters = new DynamicParameters();
        parameters.Add("Text", stringValue);
        parameters.Add("Key", "@");
        var query = "SELECT [process].[EncryptString](@Text, @Key)";
        var result = await connection.QuerySingleAsync<String>(sql: query, param: parameters, commandType: CommandType.Text);

        return result;
      }
    }

    public async Task<string> DecryptStringAsync(string stringValue)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        var parameters = new DynamicParameters();
        parameters.Add("Text", stringValue);
        parameters.Add("Key", "@");
        var query = "SELECT [process].[DecryptString](@Text, @Key)";
        var result = await connection.QuerySingleAsync<String>(sql: query, param: parameters, commandType: CommandType.Text);

        return result;
      }
    }

    #endregion

  }

}
