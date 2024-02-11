using FluentValidation;
using iSoft.Application.DTO.iSoft.Master.Request;

namespace iSoft.Application.Validator.iSoft.Master
{

  public class RoleDto_Insert_Validator : AbstractValidator<RequestDtoRole_Insert>
  {

    public RoleDto_Insert_Validator()
    {

      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID.");
      RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("No ha indicado el nombre.");
      RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la descripción.");
      RuleFor(u => u.Observation).NotNull();
      RuleFor(u => u.StateId).NotNull().NotEmpty().WithMessage("No ha indicado el estado.");
      RuleFor(u => u.IsSystem).NotNull().NotEmpty().WithMessage("No ha indicado si el registro es de Sistema.");
      RuleFor(u => u.CreatedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de creación.");
      RuleFor(u => u.CreatedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que creó el registro.");

    }

  }

  public class RoleDto_Update_Validator : AbstractValidator<RequestDtoRole_Update>
  {

    public RoleDto_Update_Validator()
    {

      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID.");
      RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("No ha indicado el nombre.");
      RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la descripción.");
      RuleFor(u => u.Observation).NotNull();
      RuleFor(u => u.StateId).NotNull().NotEmpty().WithMessage("No ha indicado el estado.");
      RuleFor(u => u.IsSystem).NotNull().NotEmpty().WithMessage("No ha indicado si el registro es de Sistema.");
      RuleFor(u => u.LastModifiedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de modificación.");
      RuleFor(u => u.LastModifiedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que modificó el registro.");
    }

  }

  public class RoleDto_Delete_Validator : AbstractValidator<RequestDtoRole_Delete>
  {

    public RoleDto_Delete_Validator()
    {
      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID.");
    }

  }

  public class RoleDto_GetById_Validator : AbstractValidator<RequestDtoRole_GetById>
  {

    public RoleDto_GetById_Validator()
    {
      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID.");
    }

  }

  public class RoleDto_ListWithPagination_Validator : AbstractValidator<RequestDtoRole_ListWithPagination>
  {

    public RoleDto_ListWithPagination_Validator()
    {
      RuleFor(u => u.PageNumber).NotNull().NotEmpty().WithMessage("No ha indicado el número de página.");
      RuleFor(u => u.PageSize).NotNull().NotEmpty().WithMessage("No ha indicado el tamaño de página.");
    }

  }

}
