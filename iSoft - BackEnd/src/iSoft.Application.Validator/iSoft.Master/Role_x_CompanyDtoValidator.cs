using FluentValidation;
using iSoft.Application.DTO.iSoft.Master.Request;

namespace iSoft.Application.Validator.iSoft.Master
{

  public class Role_x_CompanyDto_Insert_Validator : AbstractValidator<RequestDtoRole_x_Company_Insert>
  {

    public Role_x_CompanyDto_Insert_Validator()
    {

      RuleFor(u => u.RoleId).NotNull().NotEmpty().WithMessage("No ha indicado el ID del Rol.");
      RuleFor(u => u.CompanyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID de la Compañia.");
      RuleFor(u => u.StateId).NotNull().NotEmpty().WithMessage("No ha indicado el estado.");
      RuleFor(u => u.IsSystem).NotNull().NotEmpty().WithMessage("No ha indicado si el registro es de Sistema.");
      RuleFor(u => u.CreatedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de creación.");
      RuleFor(u => u.CreatedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que creó el registro.");

    }

  }

  public class Role_x_CompanyDto_Update_Validator : AbstractValidator<RequestDtoRole_x_Company_Update>
  {

    public Role_x_CompanyDto_Update_Validator()
    {

      RuleFor(u => u.RoleId).NotNull().NotEmpty().WithMessage("No ha indicado el ID del Rol.");
      RuleFor(u => u.CompanyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID de la Compañia.");
      RuleFor(u => u.StateId).NotNull().NotEmpty().WithMessage("No ha indicado el estado.");
      RuleFor(u => u.IsSystem).NotNull().NotEmpty().WithMessage("No ha indicado si el registro es de Sistema.");
      RuleFor(u => u.LastModifiedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de modificación.");
      RuleFor(u => u.LastModifiedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que modificó el registro.");
    }

  }

  public class Role_x_CompanyDto_Delete_Validator : AbstractValidator<RequestDtoRole_x_Company_Delete>
  {

    public Role_x_CompanyDto_Delete_Validator()
    {
      RuleFor(u => u.RoleId).NotNull().NotEmpty().WithMessage("No ha indicado el ID del Rol.");
      RuleFor(u => u.CompanyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID de la Compañia.");
    }

  }

  public class Role_x_CompanyDto_GetById_Validator : AbstractValidator<RequestDtoRole_x_Company_GetById>
  {

    public Role_x_CompanyDto_GetById_Validator()
    {
      RuleFor(u => u.RoleId).NotNull().NotEmpty().WithMessage("No ha indicado el ID del Rol.");
      RuleFor(u => u.CompanyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID de la Compañia.");
    }

  }

  public class Role_x_CompanyDto_ListWithPagination_Validator : AbstractValidator<RequestDtoRole_x_Company_ListWithPagination>
  {

    public Role_x_CompanyDto_ListWithPagination_Validator()
    {
      RuleFor(u => u.PageNumber).NotNull().NotEmpty().WithMessage("No ha indicado el número de página.");
      RuleFor(u => u.PageSize).NotNull().NotEmpty().WithMessage("No ha indicado el tamaño de página.");
    }

  }

}