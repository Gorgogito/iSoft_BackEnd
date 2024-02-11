using iSoft.Cross.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace iSoft.Infrastructure.Data
{
  public class ConnectionFactory : IConnectionFactory
  {

    private readonly IConfiguration _configuration;

    public ConnectionFactory(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public IDbConnection GetConnection
    {
      get
      {
        var sqlConnection = new SqlConnection();
        if (sqlConnection == null) return null;

        sqlConnection.ConnectionString = _configuration.GetConnectionString("MasterConnection");
        sqlConnection.Open();
        return sqlConnection;
      }
    }

  }
}
