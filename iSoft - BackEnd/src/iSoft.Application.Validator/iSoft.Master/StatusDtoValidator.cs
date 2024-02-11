using FluentValidation;
using iSoft.Application.DTO.iSoft.Master.Request;

namespace iSoft.Application.Validator.iSoft.Master
{
    public class StatusDtoValidator : AbstractValidator<RequestDtoStatus_GetById>
  {

    public StatusDtoValidator()
    {
      RuleFor(u => u.KeyId).NotNull().NotEmpty().WithMessage("No ha indicado el ID."); 
    }

  }
}
