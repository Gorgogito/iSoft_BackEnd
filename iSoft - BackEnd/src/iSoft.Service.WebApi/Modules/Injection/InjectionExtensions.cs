using iSoft.Application.Interface.iSoft.Master;
using iSoft.Application.Main.iSoft.Master;
using iSoft.Cross.Common;
using iSoft.Cross.Logging;
using iSoft.Domain.Core.iSoft.Master;
using iSoft.Domain.Interface.iSoft.Master;
using iSoft.Infrastructure.Data;
using iSoft.Infrastructure.Interface.iSoft.Master;
using iSoft.Infrastructure.Repository.iSoft.Master;
using iSoft.Infrastructure.Repository.iSoft.Master.Encrypting;

namespace iSoft.Service.WebApi.Modules.Injection
{
  public static class InjectionExtensions
  {

    public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddSingleton<IConfiguration>(configuration);
      services.AddSingleton<IConnectionFactory, ConnectionFactory>();

      services.AddScoped<IStatusApplication, StatusApplication>();
      services.AddScoped<IStatusDomain, StatusDomain>();
      services.AddScoped<IStatusRepository, StatusRepository>();

      services.AddScoped<IAuthenticateApplication, AuthenticateApplication>();
      services.AddScoped<IAuthenticateDomain, AuthenticateDomain>();
      services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();

      services.AddScoped<IRoleApplication, RoleApplication>();
      services.AddScoped<IRoleDomain, RoleDomain>();
      services.AddScoped<IRoleRepository, RoleRepository>();

      services.AddScoped<IUserApplication, UserApplication>();
      services.AddScoped<IUserDomain, UserDomain>();
      services.AddScoped<IUserRepository, UserRepository>();

      services.AddScoped<ICompanyApplication, CompanyApplication>();
      services.AddScoped<ICompanyDomain, CompanyDomain>();
      services.AddScoped<ICompanyRepository, CompanyRepository>();

      services.AddScoped<IRole_x_CompanyApplication, Role_x_CompanyApplication>();
      services.AddScoped<IRole_x_CompanyDomain, Role_x_CompanyDomain>();
      services.AddScoped<IRole_x_CompanyRepository, Role_x_CompanyRepository>();

      services.AddScoped<IEncryptingApplication, EncryptingApplication>();
      services.AddScoped<IEncryptingDomain, EncryptingDomain>();
      services.AddScoped<IEncryptingRepository, EncryptingRepository>();

      services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

      return services;
    }

  }
}
