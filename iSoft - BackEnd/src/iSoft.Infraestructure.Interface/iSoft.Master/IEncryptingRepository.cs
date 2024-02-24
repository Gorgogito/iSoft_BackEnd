namespace iSoft.Infrastructure.Interface.iSoft.Master
{
  public interface IEncryptingRepository
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
