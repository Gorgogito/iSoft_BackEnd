using AutoMapper;
using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.DTO.iSoft.Master.Response;
using iSoft.Application.Interface.iSoft.Master;
using iSoft.Application.Validator;
using iSoft.Application.Validator.iSoft.Master;
using iSoft.Cross.Common;
using iSoft.Domain.Entity.iSoft.Master.master;
using iSoft.Domain.Interface.iSoft.Master;

namespace iSoft.Application.Main.iSoft.Master
{
  public class StatusApplication : IStatusApplication
  {

    private readonly IStatusDomain _statusDomain;
    private readonly IMapper _mapper;
    private readonly IAppLogger<StatusApplication> _logger;
    private readonly StatusDtoValidator _statusDtoValidator;

    public StatusApplication(IStatusDomain customersDomain, IMapper mapper, IAppLogger<StatusApplication> logger, StatusDtoValidator statusDtoValidator)
    {
      _statusDomain = customersDomain;
      _mapper = mapper;
      _logger = logger;
      _statusDtoValidator = statusDtoValidator;
    }

    #region Métodos Síncronos

    public Response<ResponseDtoStatus> GetByID(RequestDtoStatus_GetById request)
    {
      var response = new Response<ResponseDtoStatus>();

      var validation = _statusDtoValidator.Validate(new RequestDtoStatus_GetById() { KeyId = request.KeyId });

      if (!validation.IsValid)
      {
        response.Message = "Errores de Validación";
        response.Errors = validation.Errors;
        return response;
      }

      try
      {
        var exist = new NotRecords<Status>(_statusDomain.GetByID(request.KeyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = _mapper.Map<ResponseDtoStatus>(exist.Record);

        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public Response<IEnumerable<ResponseDtoStatus>> List()
    {
      var response = new Response<IEnumerable<ResponseDtoStatus>>();
      try
      {
        var entity = _statusDomain.List();
        response.Data = _mapper.Map<IEnumerable<ResponseDtoStatus>>(entity);
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

    public async Task<Response<ResponseDtoStatus>> GetByIDAsync(RequestDtoStatus_GetById request)
    {
      var response = new Response<ResponseDtoStatus>();

      var validation = _statusDtoValidator.Validate(new RequestDtoStatus_GetById()
      {
        KeyId = request.KeyId
      }
      );

      if (!validation.IsValid)
      {
        response.Message = "Errores de Validación";
        response.Errors = validation.Errors;
        return response;
      }

      try
      {
        var exist = new NotRecords<Status>(_statusDomain.GetByIDAsync(request.KeyId).Result);
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = _mapper.Map<ResponseDtoStatus>(exist.Record);

        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public async Task<Response<IEnumerable<ResponseDtoStatus>>> ListAsync()
    {
      var response = new Response<IEnumerable<ResponseDtoStatus>>();
      try
      {
        var entity = await _statusDomain.ListAsync();
        response.Data = _mapper.Map<IEnumerable<ResponseDtoStatus>>(entity);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    #endregion

  }
}
