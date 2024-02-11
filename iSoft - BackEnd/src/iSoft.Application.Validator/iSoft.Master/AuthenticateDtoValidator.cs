using FluentValidation;
using iSoft.Application.DTO.iSoft.Master.Response;

namespace iSoft.Application.Validator.iSoft.Master
{
    public class AuthenticateDtoValidator : AbstractValidator<ResponseDtoAuthenticate>
  {

    public AuthenticateDtoValidator()
    {
      RuleFor(u => u.UserName).NotNull().NotEmpty().WithMessage("No ha indicado el nombre de usuario.");
      RuleFor(u => u.Password).NotNull().NotEmpty().WithMessage("No ha indicado el password de usuario.");
    }

  }
}