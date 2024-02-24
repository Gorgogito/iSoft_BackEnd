namespace iSoft.Domain.Interface.iSoft.Master
{
  public interface IEncryptingDomain
  {

    #region Métodos Síncronos

    string EncryptString(string stringValue);

    string DecryptString(string stringValue);

    #endregion

    #region Métodos Asíncronos

    Task<string> EncryptStringAsync(string stringValue);

    Task<string> DecryptStringAsync(string stringValue);

    #endregion

  }
}
