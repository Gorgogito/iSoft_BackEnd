using AutoMapper;
using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.DTO.iSoft.Master.Response;
using iSoft.Application.Interface.iSoft.Master;
using iSoft.Application.Validator;
using iSoft.Application.Validator.iSoft.Master;
using iSoft.Cross.Common;
using iSoft.Domain.Entity.iSoft.Master.identy;
using iSoft.Domain.Interface.iSoft.Master;

namespace iSoft.Application.Main.iSoft.Master
{
  public class UserApplication : IUserApplication
  {

    #region Variables Privadas

    private readonly IUserDomain _entDomain;
    private readonly IMapper _mapper;
    private readonly IAppLogger<UserApplication> _logger;
    private readonly UserDto_Insert_Validator _insertDtoValidator;
    private readonly UserDto_Update_Validator _updateDtoValidator;
    private readonly UserDto_Delete_Validator _deleteDtoValidator;
    private readonly UserDto_GetById_Validator _getByIdDtoValidator;
    private readonly UserDto_ListWithPagination_Validator _withPaginatioDtoValidator;

    #endregion

    #region Constructor

    public UserApplication
    (
     IUserDomain entDomain,
     IMapper mapper,
     IAppLogger<UserApplication> logger,
     UserDto_Insert_Validator insertDtoValidator,
     UserDto_Update_Validator updateDtoValidator,
     UserDto_Delete_Validator deleteDtoValidator,
     UserDto_GetById_Validator getByIdDtoValidator,
     UserDto_ListWithPagination_Validator withPaginatioDtoValidator
    )
    {
      _entDomain = entDomain;
      _mapper = mapper;
      _logger = logger;
      _insertDtoValidator = insertDtoValidator;
      _updateDtoValidator = updateDtoValidator;
      _deleteDtoValidator = deleteDtoValidator;
      _getByIdDtoValidator = getByIdDtoValidator;
      _withPaginatioDtoValidator = withPaginatioDtoValidator;
    }

    #endregion

    #region Métodos Síncronos

    public Response<bool> Insert(RequestDtoUser_Insert request)
    {
      var response = new Response<bool>();

      var validation = _insertDtoValidator.Validate(new RequestDtoUser_Insert()
      {

        KeyId = request.KeyId,
        UserName = request.UserName,
        Password = request.Password,
        Description = request.Description,
        Observation = request.Observation,
        Names = request.Names,
        Surnames = request.Surnames,
        Phone = request.Phone,
        EMail = request.EMail,
        RoleId = request.RoleId,
        StateId = request.StateId,
        IsSystem = request.IsSystem,
        CreatedDate = request.CreatedDate,
        CreatedBy = request.CreatedBy
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
        var customer = _mapper.Map<User>(request);
        response.Data = _entDomain.Insert(customer);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Message = "Registro Exitoso!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public Response<bool> Update(RequestDtoUser_Update request)
    {
      var response = new Response<bool>();

      var validation = _updateDtoValidator.Validate(new RequestDtoUser_Update()
      {
        KeyId = request.KeyId,
        UserName = request.UserName,
        Password = request.Password,
        Description = request.Description,
        Observation = request.Observation,
        Names = request.Names,
        Surnames = request.Surnames,
        Phone = request.Phone,
        EMail = request.EMail,
        RoleId = request.RoleId,
        StateId = request.StateId,
        IsSystem = request.IsSystem,
        LastModifiedDate = request.LastModifiedDate,
        LastModifiedBy = request.LastModifiedBy
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

        var exist = new NotRecords<User>(_entDomain.GetById(request.KeyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        var customer = _mapper.Map<User>(request);
        response.Data = _entDomain.Update(customer);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Message = "Actualización Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public Response<bool> Delete(RequestDtoUser_Delete request)
    {
      var response = new Response<bool>();

      var validation = _deleteDtoValidator.Validate(new RequestDtoUser_Delete()
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
        var exist = new NotRecords<User>(_entDomain.GetById(request.KeyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = _entDomain.Delete(request.KeyId);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Message = "Eliminación Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public Response<ResponseDtoUser> GetById(RequestDtoUser_GetById request)
    {
      var response = new Response<ResponseDtoUser>();

      var validation = _getByIdDtoValidator.Validate(new RequestDtoUser_GetById()
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
        var exist = new NotRecords<User>(_entDomain.GetById(request.KeyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = _mapper.Map<ResponseDtoUser>(exist.Record);

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

    public Response<IEnumerable<ResponseDtoUser>> List()
    {
      var response = new Response<IEnumerable<ResponseDtoUser>>();
      try
      {
        var entity = _entDomain.List();
        response.Data = _mapper.Map<IEnumerable<ResponseDtoUser>>(entity);
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

    public Response<IEnumerable<ResponseDtoUser>> ListWithPagination(RequestDtoUser_ListWithPagination request)
    {
      var response = new Response<IEnumerable<ResponseDtoUser>>();

      var validation = _withPaginatioDtoValidator.Validate(new RequestDtoUser_ListWithPagination()
      {
        PageNumber = request.PageNumber,
        PageSize = request.PageSize
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

        var req = _entDomain.ListWithPagination(request.PageNumber, request.PageSize);
        response.Data = _mapper.Map<IEnumerable<ResponseDtoUser>>(req);


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

    public async Task<Response<bool>> InsertAsync(RequestDtoUser_Insert request)
    {
      var response = new Response<bool>();

      var validation = _insertDtoValidator.Validate(new RequestDtoUser_Insert()
      {

        KeyId = request.KeyId,
        UserName = request.UserName,
        Password = request.Password,
        Description = request.Description,
        Observation = request.Observation,
        Names = request.Names,
        Surnames = request.Surnames,
        Phone = request.Phone,
        EMail = request.EMail,
        RoleId = request.RoleId,
        StateId = request.StateId,
        IsSystem = request.IsSystem,
        CreatedDate = request.CreatedDate,
        CreatedBy = request.CreatedBy
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
        var entity = _mapper.Map<User>(request);
        response.Data = await _entDomain.InsertAsync(entity);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Message = "Registro Exitoso!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public async Task<Response<bool>> UpdateAsync(RequestDtoUser_Update request)
    {
      var response = new Response<bool>();

      var validation = _updateDtoValidator.Validate(new RequestDtoUser_Update()
      {
        KeyId = request.KeyId,
        UserName = request.UserName,
        Password = request.Password,
        Description = request.Description,
        Observation = request.Observation,
        Names = request.Names,
        Surnames = request.Surnames,
        Phone = request.Phone,
        EMail = request.EMail,
        RoleId = request.RoleId,
        StateId = request.StateId,
        IsSystem = request.IsSystem,
        LastModifiedDate = request.LastModifiedDate,
        LastModifiedBy = request.LastModifiedBy
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

        var exist = new NotRecords<User>(_entDomain.GetById(request.KeyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        var entity = _mapper.Map<User>(request);
        response.Data = await _entDomain.UpdateAsync(entity);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Message = "Actualización Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public async Task<Response<bool>> DeleteAsync(RequestDtoUser_Delete request)
    {
      var response = new Response<bool>();

      var validation = _deleteDtoValidator.Validate(new RequestDtoUser_Delete()
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
        var exist = new NotRecords<User>(_entDomain.GetById(request.KeyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = await _entDomain.DeleteAsync(request.KeyId);

        if (response.Data)
        {
          response.IsSuccess = true;
          response.Message = "Eliminación Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public async Task<Response<ResponseDtoUser>> GetByIdAsync(RequestDtoUser_GetById request)
    {
      var response = new Response<ResponseDtoUser>();

      var validation = _getByIdDtoValidator.Validate(new RequestDtoUser_GetById()
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

        var exist = new NotRecords<User>(_entDomain.GetById(request.KeyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = _mapper.Map<ResponseDtoUser>(exist.Record);

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

    public async Task<Response<IEnumerable<ResponseDtoUser>>> ListAsync()
    {
      var response = new Response<IEnumerable<ResponseDtoUser>>();
      try
      {
        var entity = await _entDomain.ListAsync();
        response.Data = _mapper.Map<IEnumerable<ResponseDtoUser>>(entity);
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

    public async Task<Response<IEnumerable<ResponseDtoUser>>> ListWithPaginationAsync(RequestDtoUser_ListWithPagination request)
    {
      var response = new Response<IEnumerable<ResponseDtoUser>>();

      var validation = _withPaginatioDtoValidator.Validate(new RequestDtoUser_ListWithPagination()
      {
        PageNumber = request.PageNumber,
        PageSize = request.PageSize
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
        var req = await _entDomain.ListWithPaginationAsync(request.PageNumber, request.PageSize);
        response.Data = _mapper.Map<IEnumerable<ResponseDtoUser>>(req);

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
