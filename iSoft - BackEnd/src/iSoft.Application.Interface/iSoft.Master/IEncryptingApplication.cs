using iSoft.Cross.Common;

namespace iSoft.Application.Interface.iSoft.Master
{
  public interface IEncryptingApplication
  {

    #region Métodos Síncronos

    Response<string> EncryptString(string stringValue);
    Response<string> DecryptString(string stringValue);

    #endregion

    #region Métodos Asíncronos

    Task<Response<string>> EncryptStringAsync(string stringValue);
    Task<Response<string>> DecryptStringAsync(string stringValue);

    #endregion

  }
}
