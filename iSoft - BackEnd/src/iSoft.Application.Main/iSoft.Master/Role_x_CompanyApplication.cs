using AutoMapper;
using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.DTO.iSoft.Master.Response;
using iSoft.Application.Interface.iSoft.Master;
using iSoft.Application.Validator.iSoft.Master;
using iSoft.Application.Validator;
using iSoft.Cross.Common;
using iSoft.Domain.Entity.iSoft.Master.identy;
using iSoft.Domain.Interface.iSoft.Master;

namespace iSoft.Application.Main.iSoft.Master
{
  public class Role_x_CompanyApplication: IRole_x_CompanyApplication
  {

    #region Variables Privadas

    private readonly IRole_x_CompanyDomain _entDomain;
    private readonly IMapper _mapper;
    private readonly IAppLogger<Role_x_CompanyApplication> _logger;
    private readonly Role_x_CompanyDto_Insert_Validator _insertDtoValidator;
    private readonly Role_x_CompanyDto_Update_Validator _updateDtoValidator;
    private readonly Role_x_CompanyDto_Delete_Validator _deleteDtoValidator;
    private readonly Role_x_CompanyDto_GetById_Validator _getByIdDtoValidator;
    private readonly Role_x_CompanyDto_ListWithPagination_Validator _withPaginatioDtoValidator;

    #endregion

    #region Constructor

    public Role_x_CompanyApplication
    (
     IRole_x_CompanyDomain entDomain,
     IMapper mapper,
     IAppLogger<Role_x_CompanyApplication> logger,
     Role_x_CompanyDto_Insert_Validator insertDtoValidator,
     Role_x_CompanyDto_Update_Validator updateDtoValidator,
     Role_x_CompanyDto_Delete_Validator deleteDtoValidator,
     Role_x_CompanyDto_GetById_Validator getByIdDtoValidator,
     Role_x_CompanyDto_ListWithPagination_Validator withPaginatioDtoValidator
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

    public Response<bool> Insert(RequestDtoRole_x_Company_Insert request)
    {
      var response = new Response<bool>();

      var validation = _insertDtoValidator.Validate(new RequestDtoRole_x_Company_Insert()
      {
        RoleId = request.RoleId,
        CompanyId = request.CompanyId,
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
        var req = _mapper.Map<Role_x_Company>(request);
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

    public Response<bool> Update(RequestDtoRole_x_Company_Update request)
    {
      var response = new Response<bool>();

      var validation = _updateDtoValidator.Validate(new RequestDtoRole_x_Company_Update()
      {
        RoleId = request.RoleId,
        CompanyId = request.CompanyId,
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

        var exist = new NotRecords<Role_x_Company>(_entDomain.GetById(request.RoleId, request.CompanyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        var req = _mapper.Map<Role_x_Company>(request);
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

    public Response<bool> Delete(RequestDtoRole_x_Company_Delete request)
    {
      var response = new Response<bool>();

      var validation = _deleteDtoValidator.Validate(new RequestDtoRole_x_Company_Delete()
      {
        RoleId = request.RoleId,
        CompanyId = request.CompanyId
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

        var exist = new NotRecords<Role_x_Company>(_entDomain.GetById(request.RoleId, request.CompanyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = _entDomain.Delete(request.RoleId, request.CompanyId);

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

    public Response<ResponseDtoRole_x_Company> GetById(RequestDtoRole_x_Company_GetById request)
    {
      var response = new Response<ResponseDtoRole_x_Company>();

      var validation = _getByIdDtoValidator.Validate(new RequestDtoRole_x_Company_GetById()
      {
        RoleId = request.RoleId,
        CompanyId = request.CompanyId
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
        var exist = new NotRecords<Role_x_Company>(_entDomain.GetById(request.RoleId, request.CompanyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = _mapper.Map<ResponseDtoRole_x_Company>(exist.Record);

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

    public Response<IEnumerable<ResponseDtoRole_x_Company>> List()
    {
      var response = new Response<IEnumerable<ResponseDtoRole_x_Company>>();
      try
      {
        var entity = _entDomain.List();
        response.Data = _mapper.Map<IEnumerable<ResponseDtoRole_x_Company>>(entity);
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

    public Response<IEnumerable<ResponseDtoRole_x_Company>> ListWithPagination(RequestDtoRole_x_Company_ListWithPagination request)
    {
      var response = new Response<IEnumerable<ResponseDtoRole_x_Company>>();

      var validation = _withPaginatioDtoValidator.Validate(new RequestDtoRole_x_Company_ListWithPagination()
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
        response.Data = _mapper.Map<IEnumerable<ResponseDtoRole_x_Company>>(req);

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

    public async Task<Response<bool>> InsertAsync(RequestDtoRole_x_Company_Insert request)
    {
      var response = new Response<bool>();

      var validation = _insertDtoValidator.Validate(new RequestDtoRole_x_Company_Insert()
      {
        RoleId = request.RoleId,
        CompanyId = request.CompanyId,
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
        var req = _mapper.Map<Role_x_Company>(request);
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

    public async Task<Response<bool>> UpdateAsync(RequestDtoRole_x_Company_Update request)
    {
      var response = new Response<bool>();

      var validation = _updateDtoValidator.Validate(new RequestDtoRole_x_Company_Update()
      {
        RoleId = request.RoleId,
        CompanyId = request.CompanyId,
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
        var exist = new NotRecords<Role_x_Company>(_entDomain.GetByIdAsync(request.RoleId, request.CompanyId).Result);
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }
        var req = _mapper.Map<Role_x_Company>(request);
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

    public async Task<Response<bool>> DeleteAsync(RequestDtoRole_x_Company_Delete request)
    {
      var response = new Response<bool>();

      var validation = _deleteDtoValidator.Validate(new RequestDtoRole_x_Company_Delete()
      {
        RoleId = request.RoleId,
        CompanyId = request.CompanyId
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

        var exist = new NotRecords<Role_x_Company>(_entDomain.GetByIdAsync(request.RoleId, request.CompanyId).Result);
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = await _entDomain.DeleteAsync(request.RoleId, request.CompanyId);

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

    public async Task<Response<ResponseDtoRole_x_Company>> GetByIdAsync(RequestDtoRole_x_Company_GetById request)
    {
      var response = new Response<ResponseDtoRole_x_Company>();

      var validation = _getByIdDtoValidator.Validate(new RequestDtoRole_x_Company_GetById()
      {
        RoleId = request.RoleId,
        CompanyId = request.CompanyId
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
        var exist = new NotRecords<Role_x_Company>(_entDomain.GetByIdAsync(request.RoleId, request.CompanyId).Result);
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = _mapper.Map<ResponseDtoRole_x_Company>(exist.Record);

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

    public async Task<Response<IEnumerable<ResponseDtoRole_x_Company>>> ListAsync()
    {
      var response = new Response<IEnumerable<ResponseDtoRole_x_Company>>();
      try
      {
        var entity = await _entDomain.ListAsync();
        response.Data = _mapper.Map<IEnumerable<ResponseDtoRole_x_Company>>(entity);
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

    public async Task<Response<IEnumerable<ResponseDtoRole_x_Company>>> ListWithPaginationAsync(RequestDtoRole_x_Company_ListWithPagination request)
    {
      var response = new Response<IEnumerable<ResponseDtoRole_x_Company>>();

      var validation = _withPaginatioDtoValidator.Validate(new RequestDtoRole_x_Company_ListWithPagination()
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
        response.Data = _mapper.Map<IEnumerable<ResponseDtoRole_x_Company>>(req);

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
