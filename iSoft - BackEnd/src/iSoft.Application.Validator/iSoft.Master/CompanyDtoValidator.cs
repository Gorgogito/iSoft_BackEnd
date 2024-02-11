using FluentValidation;
using iSoft.Application.DTO.iSoft.Master.Request;

namespace iSoft.Application.Validator.iSoft.Master
{

  public class CompanyDto_Insert_Validator : AbstractValidator<RequestDtoCompany_Insert>
  {

    public CompanyDto_Insert_Validator()
    {

      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID.");
      RuleFor(u => u.Ruc).NotNull().NotEmpty().WithMessage("No ha indicado el RUC.");
      RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la descripción.");
      RuleFor(u => u.Observation).NotNull();
      RuleFor(u => u.Address).NotNull().NotEmpty().WithMessage("No ha indicado la dirección.");
      RuleFor(u => u.Agent).NotNull().WithMessage("No ha indicado el Responsable.");
      RuleFor(u => u.Phone).NotNull().WithMessage("No ha indicado el Telefono.");
      RuleFor(u => u.EMail).NotNull().WithMessage("No ha indicado el Correo.");
      RuleFor(u => u.Web).NotNull().WithMessage("No ha indicado la Página Web.");
      RuleFor(u => u.StateId).NotNull().NotEmpty().WithMessage("No ha indicado el estado.");
      RuleFor(u => u.IsSystem).NotNull().NotEmpty().WithMessage("No ha indicado si el registro es de Sistema.");
      RuleFor(u => u.CreatedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de creación.");
      RuleFor(u => u.CreatedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que creó el registro.");

    }

  }

  public class CompanyDto_Update_Validator : AbstractValidator<RequestDtoCompany_Update>
  {

    public CompanyDto_Update_Validator()
    {

      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID.");
      RuleFor(u => u.Ruc).NotNull().NotEmpty().WithMessage("No ha indicado el RUC.");
      RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la descripción.");
      RuleFor(u => u.Observation).NotNull();
      RuleFor(u => u.Address).NotNull().NotEmpty().WithMessage("No ha indicado la dirección.");
      RuleFor(u => u.Agent).NotNull().WithMessage("No ha indicado el Responsable.");
      RuleFor(u => u.Phone).NotNull().WithMessage("No ha indicado el Telefono.");
      RuleFor(u => u.EMail).NotNull().WithMessage("No ha indicado el Correo.");
      RuleFor(u => u.Web).NotNull().WithMessage("No ha indicado la Página Web.");
      RuleFor(u => u.StateId).NotNull().NotEmpty().WithMessage("No ha indicado el estado.");
      RuleFor(u => u.IsSystem).NotNull().NotEmpty().WithMessage("No ha indicado si el registro es de Sistema.");
      RuleFor(u => u.LastModifiedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de modificación.");
      RuleFor(u => u.LastModifiedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que modificó el registro.");

    }

  }

  public class CompanyDto_Delete_Validator : AbstractValidator<RequestDtoCompany_Delete>
  {

    public CompanyDto_Delete_Validator()
    {
      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID.");
    }

  }

  public class CompanyDto_GetById_Validator : AbstractValidator<RequestDtoCompany_GetById>
  {

    public CompanyDto_GetById_Validator()
    {
      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID.");
    }

  }

  public class CompanyDto_ListWithPagination_Validator : AbstractValidator<RequestDtoCompany_ListWithPagination>
  {

    public CompanyDto_ListWithPagination_Validator()
    {
      RuleFor(u => u.PageNumber).NotNull().NotEmpty().WithMessage("No ha indicado el número de página.");
      RuleFor(u => u.PageSize).NotNull().NotEmpty().WithMessage("No ha indicado el tamaño de página.");
    }

  }

}
