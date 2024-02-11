using iSoft.Application.Validator.iSoft.Master;

namespace iSoft.Service.WebApi.Modules.Validator
{
  public static class ValidatorExtensions
  {

    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
      services.AddTransient<AuthenticateDtoValidator>();

      services.AddTransient<StatusDtoValidator>();

      services.AddTransient<RoleDto_Insert_Validator>();
      services.AddTransient<RoleDto_Update_Validator>();
      services.AddTransient<RoleDto_Delete_Validator>();
      services.AddTransient<RoleDto_GetById_Validator>();
      services.AddTransient<RoleDto_ListWithPagination_Validator>();

      services.AddTransient<UserDto_Insert_Validator>();
      services.AddTransient<UserDto_Update_Validator>();
      services.AddTransient<UserDto_Delete_Validator>();
      services.AddTransient<UserDto_GetById_Validator>();
      services.AddTransient<UserDto_ListWithPagination_Validator>();

      services.AddTransient<CompanyDto_Insert_Validator>();
      services.AddTransient<CompanyDto_Update_Validator>();
      services.AddTransient<CompanyDto_Delete_Validator>();
      services.AddTransient<CompanyDto_GetById_Validator>();
      services.AddTransient<CompanyDto_ListWithPagination_Validator>();

      services.AddTransient<Role_x_CompanyDto_Insert_Validator>();
      services.AddTransient<Role_x_CompanyDto_Update_Validator>();
      services.AddTransient<Role_x_CompanyDto_Delete_Validator>();
      services.AddTransient<Role_x_CompanyDto_GetById_Validator>();
      services.AddTransient<Role_x_CompanyDto_ListWithPagination_Validator>();

      return services;
    }

  }
}
