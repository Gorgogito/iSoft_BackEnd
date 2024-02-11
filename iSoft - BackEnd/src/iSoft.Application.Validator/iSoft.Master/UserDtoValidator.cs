using FluentValidation;
using iSoft.Application.DTO.iSoft.Master.Request;

namespace iSoft.Application.Validator.iSoft.Master
{

  public class UserDto_Insert_Validator : AbstractValidator<RequestDtoUser_Insert>
  {

    public UserDto_Insert_Validator()
    {

      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID.");
      RuleFor(u => u.UserName).NotNull().NotEmpty().WithMessage("No ha indicado el UserName.");
      RuleFor(u => u.Password).NotNull().NotEmpty().WithMessage("No ha indicado el Password.");      
      RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la descripción.");
      RuleFor(u => u.Observation).NotNull();
      RuleFor(u => u.Names).NotNull().NotEmpty().WithMessage("No ha indicado los nombres.");
      RuleFor(u => u.Surnames).NotNull().NotEmpty().WithMessage("No ha indicado los apellidos.");
      RuleFor(u => u.Phone).NotNull();
      RuleFor(u => u.EMail).NotNull();
      RuleFor(u => u.RoleId).NotNull().NotEmpty().WithMessage("No ha indicado el Rol.");
      RuleFor(u => u.StateId).NotNull().NotEmpty().WithMessage("No ha indicado el estado.");
      RuleFor(u => u.IsSystem).NotNull().NotEmpty().WithMessage("No ha indicado si el registro es de Sistema.");
      RuleFor(u => u.CreatedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de creación.");
      RuleFor(u => u.CreatedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que creó el registro.");

    }

  }

  public class UserDto_Update_Validator : AbstractValidator<RequestDtoUser_Update>
  {

    public UserDto_Update_Validator()
    {

      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID.");
      RuleFor(u => u.UserName).NotNull().NotEmpty().WithMessage("No ha indicado el UserName.");
      RuleFor(u => u.Password).NotNull().NotEmpty().WithMessage("No ha indicado el Password.");
      RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la descripción.");
      RuleFor(u => u.Observation).NotNull();
      RuleFor(u => u.Names).NotNull().NotEmpty().WithMessage("No ha indicado los nombres.");
      RuleFor(u => u.Surnames).NotNull().NotEmpty().WithMessage("No ha indicado los apellidos.");
      RuleFor(u => u.Phone).NotNull();
      RuleFor(u => u.EMail).NotNull();
      RuleFor(u => u.RoleId).NotNull().NotEmpty().WithMessage("No ha indicado el Rol.");
      RuleFor(u => u.StateId).NotNull().NotEmpty().WithMessage("No ha indicado el estado.");
      RuleFor(u => u.IsSystem).NotNull().NotEmpty().WithMessage("No ha indicado si el registro es de Sistema.");
      RuleFor(u => u.LastModifiedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de modificación.");
      RuleFor(u => u.LastModifiedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que modificó el registro.");
    }

  }

  public class UserDto_Delete_Validator : AbstractValidator<RequestDtoUser_Delete>
  {

    public UserDto_Delete_Validator()
    {
      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID.");
    }

  }

  public class UserDto_GetById_Validator : AbstractValidator<RequestDtoUser_GetById>
  {

    public UserDto_GetById_Validator()
    {
      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID.");
    }

  }

  public class UserDto_ListWithPagination_Validator : AbstractValidator<RequestDtoUser_ListWithPagination>
  {

    public UserDto_ListWithPagination_Validator()
    {
      RuleFor(u => u.PageNumber).NotNull().NotEmpty().WithMessage("No ha indicado el número de página.");
      RuleFor(u => u.PageSize).NotNull().NotEmpty().WithMessage("No ha indicado el tamaño de página.");
    }

  }

}
