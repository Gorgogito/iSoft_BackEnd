using iSoft.Domain.Interface.iSoft.Master;
using iSoft.Infrastructure.Interface.iSoft.Master;

namespace iSoft.Domain.Core.iSoft.Master
{
  public class EncryptingDomain: IEncryptingDomain
  {

    private readonly IEncryptingRepository _encryptingRepository;

    public EncryptingDomain(IEncryptingRepository encryptingRepository)
    {
      _encryptingRepository = encryptingRepository;
    }

    #region Métodos Síncronos

    public string EncryptString(string stringValue)
    {
      return _encryptingRepository.EncryptString(stringValue);
    }

    public string DecryptString(string stringValue)
    {
      return _encryptingRepository.DecryptString(stringValue);
    }

    #endregion

    #region Métodos Síncronos

    public async Task<string> EncryptStringAsync(string stringValue)
    {
      return await _encryptingRepository.EncryptStringAsync(stringValue);
    }

    public async Task<string> DecryptStringAsync(string stringValue)
    {
      return await _encryptingRepository.DecryptStringAsync(stringValue);
    }

    #endregion

  }
}
