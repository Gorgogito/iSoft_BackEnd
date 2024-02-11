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
  public class RoleApplication : IRoleApplication
  {

    #region Variables Privadas

    private readonly IRoleDomain _entDomain;
    private readonly IMapper _mapper;
    private readonly IAppLogger<RoleApplication> _logger;
    private readonly RoleDto_Insert_Validator _insertDtoValidator;
    private readonly RoleDto_Update_Validator _updateDtoValidator;
    private readonly RoleDto_Delete_Validator _deleteDtoValidator;
    private readonly RoleDto_GetById_Validator _getByIdDtoValidator;
    private readonly RoleDto_ListWithPagination_Validator _withPaginatioDtoValidator;

    #endregion

    #region Constructor

    public RoleApplication
    (
     IRoleDomain entDomain,
     IMapper mapper,
     IAppLogger<RoleApplication> logger,
     RoleDto_Insert_Validator insertDtoValidator,
     RoleDto_Update_Validator updateDtoValidator,
     RoleDto_Delete_Validator deleteDtoValidator,
     RoleDto_GetById_Validator getByIdDtoValidator,
     RoleDto_ListWithPagination_Validator withPaginatioDtoValidator
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

    public Response<bool> Insert(RequestDtoRole_Insert request)
    {
      var response = new Response<bool>();

      var validation = _insertDtoValidator.Validate(new RequestDtoRole_Insert()
      {
        KeyId = request.KeyId,
        Name = request.Name,
        Description = request.Description,
        Observation = request.Observation,
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
        var req = _mapper.Map<Role>(request);
        response.Data = _entDomain.Insert(req);
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

    public Response<bool> Update(RequestDtoRole_Update request)
    {
      var response = new Response<bool>();

      var validation = _updateDtoValidator.Validate(new RequestDtoRole_Update()
      {
        KeyId = request.KeyId,
        Name = request.Name,
        Description = request.Description,
        Observation = request.Observation,
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

        var exist = new NotRecords<Role>(_entDomain.GetById(request.KeyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        var req = _mapper.Map<Role>(request);
        response.Data = _entDomain.Update(req);
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

    public Response<bool> Delete(RequestDtoRole_Delete request)
    {
      var response = new Response<bool>();

      var validation = _deleteDtoValidator.Validate(new RequestDtoRole_Delete()
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

        var exist = new NotRecords<Role>(_entDomain.GetById(request.KeyId));
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

    public Response<ResponseDtoRole> GetById(RequestDtoRole_GetById request)
    {
      var response = new Response<ResponseDtoRole>();

      var validation = _getByIdDtoValidator.Validate(new RequestDtoRole_GetById()
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
        var exist = new NotRecords<Role>(_entDomain.GetById(request.KeyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = _mapper.Map<ResponseDtoRole>(exist.Record);

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

    public Response<IEnumerable<ResponseDtoRole>> List()
    {
      var response = new Response<IEnumerable<ResponseDtoRole>>();
      try
      {
        var entity = _entDomain.List();
        response.Data = _mapper.Map<IEnumerable<ResponseDtoRole>>(entity);
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

    public Response<IEnumerable<ResponseDtoRole>> ListWithPagination(RequestDtoRole_ListWithPagination request)
    {
      var response = new Response<IEnumerable<ResponseDtoRole>>();

      var validation = _withPaginatioDtoValidator.Validate(new RequestDtoRole_ListWithPagination()
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
        response.Data = _mapper.Map<IEnumerable<ResponseDtoRole>>(req);

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

    public async Task<Response<bool>> InsertAsync(RequestDtoRole_Insert request)
    {
      var response = new Response<bool>();

      var validation = _insertDtoValidator.Validate(new RequestDtoRole_Insert()
      {
        KeyId = request.KeyId,
        Name = request.Name,
        Description = request.Description,
        Observation = request.Observation,
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
        var req = _mapper.Map<Role>(request);
        response.Data = await _entDomain.InsertAsync(req);
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

    public async Task<Response<bool>> UpdateAsync(RequestDtoRole_Update request)
    {
      var response = new Response<bool>();

      var validation = _updateDtoValidator.Validate(new RequestDtoRole_Update()
      {
        KeyId = request.KeyId,
        Name = request.Name,
        Description = request.Description,
        Observation = request.Observation,
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
        var exist = new NotRecords<Role>(_entDomain.GetByIdAsync(request.KeyId).Result);
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }
        var req = _mapper.Map<Role>(request);
        response.Data = await _entDomain.UpdateAsync(req);
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

    public async Task<Response<bool>> DeleteAsync(RequestDtoRole_Delete request)
    {
      var response = new Response<bool>();

      var validation = _deleteDtoValidator.Validate(new RequestDtoRole_Delete()
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

        var exist = new NotRecords<Role>(_entDomain.GetByIdAsync(request.KeyId).Result);
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

    public async Task<Response<ResponseDtoRole>> GetByIdAsync(RequestDtoRole_GetById request)
    {
      var response = new Response<ResponseDtoRole>();

      var validation = _getByIdDtoValidator.Validate(new RequestDtoRole_GetById()
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
        var exist = new NotRecords<Role>(_entDomain.GetByIdAsync(request.KeyId).Result);
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = _mapper.Map<ResponseDtoRole>(exist.Record);

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

    public async Task<Response<IEnumerable<ResponseDtoRole>>> ListAsync()
    {
      var response = new Response<IEnumerable<ResponseDtoRole>>();
      try
      {
        var entity = await _entDomain.ListAsync();
        response.Data = _mapper.Map<IEnumerable<ResponseDtoRole>>(entity);
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

    public async Task<Response<IEnumerable<ResponseDtoRole>>> ListWithPaginationAsync(RequestDtoRole_ListWithPagination request)
    {
      var response = new Response<IEnumerable<ResponseDtoRole>>();

      var validation = _withPaginatioDtoValidator.Validate(new RequestDtoRole_ListWithPagination()
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
        response.Data = _mapper.Map<IEnumerable<ResponseDtoRole>>(req);

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