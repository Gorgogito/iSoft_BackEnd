using AutoMapper;
using iSoft.Application.DTO.iSoft.Master.Response;
using iSoft.Application.Interface.iSoft.Master;
using iSoft.Application.Validator;
using iSoft.Application.Validator.iSoft.Master;
using iSoft.Cross.Common;
using iSoft.Domain.Entity.iSoft.Master.identy;
using iSoft.Domain.Entity.iSoft.Master.master;
using iSoft.Domain.Interface.iSoft.Master;

namespace iSoft.Application.Main.iSoft.Master
{
    public class AuthenticateApplication: IAuthenticateApplication
  {

    private readonly IAuthenticateDomain _authenticateDomain;
    private readonly IMapper _mapper;
    private readonly AuthenticateDtoValidator _authenticateDtoValidator;

    public AuthenticateApplication(IAuthenticateDomain authenticateDomain, IMapper mapper, IAppLogger<AuthenticateApplication> logger, AuthenticateDtoValidator authenticateDtoValidator)
    {
      _authenticateDomain = authenticateDomain;
      _mapper = mapper;
      _authenticateDtoValidator = authenticateDtoValidator;
    }

    public Response<ResponseDtoAuthenticate> Authenticate(string username, string password)
    {
      var response = new Response<ResponseDtoAuthenticate>();
      var validation = _authenticateDtoValidator.Validate(new ResponseDtoAuthenticate() { UserName = username, Password = password });

      if (!validation.IsValid)
      {
        response.Message = "Errores de Validación";
        response.Errors = validation.Errors;
        return response;
      }
      try
      {
        //var user = _authenticateDomain.Authenticate(username, password);
        //response.Data = _mapper.Map<ResponseDtoAuthenticate>(user);
        //response.IsSuccess = true;
        //response.Message = "Autenticación Exitosa!!!";

        var exist = new NotRecords<Authenticate>(_authenticateDomain.Authenticate(username, password), true);
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }
        response.Data = _mapper.Map<ResponseDtoAuthenticate>(exist.Record);

        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
        }

      }
      catch (InvalidOperationException)
      {
        response.IsSuccess = true;
        response.Message = "Usuario o Contraseña incorrecta.";
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

  }
}