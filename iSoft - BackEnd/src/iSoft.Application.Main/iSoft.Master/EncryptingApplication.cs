using iSoft.Application.Interface.iSoft.Master;
using iSoft.Cross.Common;
using iSoft.Domain.Interface.iSoft.Master;

namespace iSoft.Application.Main.iSoft.Master
{
  public class EncryptingApplication: IEncryptingApplication
  {

    private readonly IEncryptingDomain _encryptingDomain;
    private readonly IAppLogger<StatusApplication> _logger;

    public EncryptingApplication(IEncryptingDomain encryptingDomain, IAppLogger<StatusApplication> logger)
    {
      _encryptingDomain = encryptingDomain;
      _logger = logger;
    }

    #region Métodos Síncronos

    public Response<string> EncryptString(string stringValue)
    {
      var response = new Response<string>();
      try
      {
        var result = _encryptingDomain.EncryptString(stringValue);

        response.Data = result;

        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
          _logger.LogInformation("Consulta Exitosa!!!");
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
        _logger.LogError(e.Message);
      }
      return response;
    }

    public Response<string> DecryptString(string stringValue)
    {
      var response = new Response<string>();
      try
      {
        var result = _encryptingDomain.DecryptString(stringValue);

        response.Data = result;

        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
          _logger.LogInformation("Consulta Exitosa!!!");
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
        _logger.LogError(e.Message);
      }
      return response;
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<Response<string>> EncryptStringAsync(string stringValue)
    {
      var response = new Response<string>();
      try
      {
        var result = _encryptingDomain.EncryptStringAsync(stringValue);

        response.Data = result.Result;

        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
          _logger.LogInformation("Consulta Exitosa!!!");
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
        _logger.LogError(e.Message);
      }
      return response;
    }

    public async Task<Response<string>> DecryptStringAsync(string stringValue)
    {
      var response = new Response<string>();
      try
      {
        var result = _encryptingDomain.DecryptStringAsync(stringValue);

        response.Data = result.Result;

        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
          _logger.LogInformation("Consulta Exitosa!!!");
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
        _logger.LogError(e.Message);
      }
      return response;
    }

    #endregion

  }
}
