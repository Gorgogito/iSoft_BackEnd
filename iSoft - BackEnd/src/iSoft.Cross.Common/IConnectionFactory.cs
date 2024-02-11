using System.Data;

namespace iSoft.Cross.Common
{
  public interface IConnectionFactory
  {

    IDbConnection GetConnection { get; }

  }
}
