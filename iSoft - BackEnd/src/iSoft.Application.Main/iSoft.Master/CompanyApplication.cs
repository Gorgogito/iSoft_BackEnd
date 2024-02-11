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
  public class CompanyApplication : ICompanyApplication
  {

    #region Variables Privadas

    private readonly ICompanyDomain _domain;
    private readonly IMapper _mapper;
    private readonly IAppLogger<CompanyApplication> _logger;
    private readonly CompanyDto_Insert_Validator _insertDtoValidator;
    private readonly CompanyDto_Update_Validator _updateDtoValidator;
    private readonly CompanyDto_Delete_Validator _deleteDtoValidator;
    private readonly CompanyDto_GetById_Validator _getByIdDtoValidator;
    private readonly CompanyDto_ListWithPagination_Validator _withPaginatioDtoValidator;

    #endregion

    #region Constructor

    public CompanyApplication
    (
     ICompanyDomain domain,
     IMapper mapper,
     IAppLogger<CompanyApplication> logger,
     CompanyDto_Insert_Validator insertDtoValidator,
     CompanyDto_Update_Validator updateDtoValidator,
     CompanyDto_Delete_Validator deleteDtoValidator,
     CompanyDto_GetById_Validator getByIdDtoValidator,
     CompanyDto_ListWithPagination_Validator withPaginatioDtoValidator
    )
    {
      _domain = domain;
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

    public Response<bool> Insert(RequestDtoCompany_Insert request)
    {
      var response = new Response<bool>();

      var validation = _insertDtoValidator.Validate(new RequestDtoCompany_Insert()
      {
        KeyId = request.KeyId,
        Ruc = request.Ruc,
        Description = request.Description,
        Observation = request.Observation,
        Address = request.Address,
        Agent = request.Agent,
        Phone = request.Phone,
        EMail = request.EMail,
        Web = request.Web,
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
        var customer = _mapper.Map<Company>(request);
        response.Data = _domain.Insert(customer);
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

    public Response<bool> Update(RequestDtoCompany_Update request)
    {
      var response = new Response<bool>();

      var validation = _updateDtoValidator.Validate(new RequestDtoCompany_Update()
      {
        KeyId = request.KeyId,
        Ruc = request.Ruc,
        Description = request.Description,
        Observation = request.Observation,
        Address = request.Address,
        Agent = request.Agent,
        Phone = request.Phone,
        EMail = request.EMail,
        Web = request.Web,
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

        var exist = new NotRecords<Company>(_domain.GetById(request.KeyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        var req = _mapper.Map<Company>(request);
        response.Data = _domain.Update(req);
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

    public Response<bool> Delete(RequestDtoCompany_Delete request)
    {
      var response = new Response<bool>();

      var validation = _deleteDtoValidator.Validate(new RequestDtoCompany_Delete()
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

        var exist = new NotRecords<Company>(_domain.GetById(request.KeyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = _domain.Delete(request.KeyId);
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

    public Response<ResponseDtoCompany> GetById(RequestDtoCompany_GetById request)
    {
      var response = new Response<ResponseDtoCompany>();

      var validation = _getByIdDtoValidator.Validate(new RequestDtoCompany_GetById()
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
        var exist = new NotRecords<Company>(_domain.GetById(request.KeyId));
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }
        response.Data = _mapper.Map<ResponseDtoCompany>(exist.Record);

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

    public Response<IEnumerable<ResponseDtoCompany>> List()
    {
      var response = new Response<IEnumerable<ResponseDtoCompany>>();
      try
      {
        var entity = _domain.List();
        response.Data = _mapper.Map<IEnumerable<ResponseDtoCompany>>(entity);
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

    public Response<IEnumerable<ResponseDtoCompany>> ListWithPagination(RequestDtoCompany_ListWithPagination request)
    {
      var response = new Response<IEnumerable<ResponseDtoCompany>>();
      try
      {

        var req = _domain.ListWithPagination(request.PageNumber, request.PageSize);
        response.Data = _mapper.Map<IEnumerable<ResponseDtoCompany>>(req);


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

    public async Task<Response<bool>> InsertAsync(RequestDtoCompany_Insert request)
    {
      var response = new Response<bool>();

      var validation = _insertDtoValidator.Validate(new RequestDtoCompany_Insert()
      {
        KeyId = request.KeyId,
        Ruc = request.Ruc,
        Description = request.Description,
        Observation = request.Observation,
        Address = request.Address,
        Agent = request.Agent,
        Phone = request.Phone,
        EMail = request.EMail,
        Web = request.Web,
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
        var entity = _mapper.Map<Company>(request);
        response.Data = await _domain.InsertAsync(entity);
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

    public async Task<Response<bool>> UpdateAsync(RequestDtoCompany_Update request)
    {
      var response = new Response<bool>();

      var validation = _updateDtoValidator.Validate(new RequestDtoCompany_Update()
      {
        KeyId = request.KeyId,
        Ruc = request.Ruc,
        Description = request.Description,
        Observation = request.Observation,
        Address = request.Address,
        Agent = request.Agent,
        Phone = request.Phone,
        EMail = request.EMail,
        Web = request.Web,
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
        var exist = new NotRecords<Company>(_domain.GetByIdAsync(request.KeyId).Result);
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }
        var req = _mapper.Map<Company>(request);
        response.Data = await _domain.UpdateAsync(req);
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

    public async Task<Response<bool>> DeleteAsync(RequestDtoCompany_Delete request)
    {
      var response = new Response<bool>();

      var validation = _deleteDtoValidator.Validate(new RequestDtoCompany_Delete()
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

        var exist = new NotRecords<Company>(_domain.GetByIdAsync(request.KeyId).Result);
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }

        response.Data = await _domain.DeleteAsync(request.KeyId);

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

    public async Task<Response<ResponseDtoCompany>> GetByIdAsync(RequestDtoCompany_GetById request)
    {
      var response = new Response<ResponseDtoCompany>();

      var validation = _getByIdDtoValidator.Validate(new RequestDtoCompany_GetById()
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
        var exist = new NotRecords<Company>(_domain.GetByIdAsync(request.KeyId).Result);
        if (!exist.Success)
        {
          response.Message = exist.Response.Message;
          response.Errors = exist.Response.Errors;
          return response;
        }
        response.Data = _mapper.Map<ResponseDtoCompany>(exist.Record);

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

    public async Task<Response<IEnumerable<ResponseDtoCompany>>> ListAsync()
    {
      var response = new Response<IEnumerable<ResponseDtoCompany>>();
      try
      {
        var entity = await _domain.ListAsync();
        response.Data = _mapper.Map<IEnumerable<ResponseDtoCompany>>(entity);
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

    public async Task<Response<IEnumerable<ResponseDtoCompany>>> ListWithPaginationAsync(RequestDtoCompany_ListWithPagination request)
    {
      var response = new Response<IEnumerable<ResponseDtoCompany>>();
      try
      {
        var req = await _domain.ListWithPaginationAsync(request.PageNumber, request.PageSize);
        response.Data = _mapper.Map<IEnumerable<ResponseDtoCompany>>(req);

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
