using Dapper;
using iSoft.Cross.Common;
using iSoft.Domain.Entity.iSoft.Master.identy;
using iSoft.Infrastructure.Interface.iSoft.Master;
using System.Data;

namespace iSoft.Infrastructure.Repository.iSoft.Master
{
  public class AuthenticateRepository : IAuthenticateRepository
  {
    private readonly IConnectionFactory _connectionFactory;

    public AuthenticateRepository(IConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    public Authenticate Authenticate(string userName, string password)
    {
      using (var connection = _connectionFactory.GetConnection)
      {
        Authenticate user = null;
        var query = "SELECT COUNT(*) FROM [identy].[User] WHERE UserName = @UserName and Password = [process].EncryptString(@Password, '@')";

        var parameters = new DynamicParameters();

        parameters.Add("UserName", userName);
        parameters.Add("Password", password);

        var exist = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.Text);
        query = "[identy].[UserGetByUserAndPassword]";

        if (exist > 0)
        { user = connection.QuerySingle<Authenticate>(query, param: parameters, commandType: CommandType.StoredProcedure); }

        return user;
      }
    }

  }
}
