using LAStEngineer.Logistic.Application.Interface;
using LAStEngineer.Logistic.Application.Interface.Persistence.Repositories.Main;
using LAStEngineer.Logistic.Infrastructure.Contexts;
using LAStEngineer.Logistic.Infrastructure.Persistence.Persistence.Repositories.Main;
using LAStEngineer.Logistic.Infrastructure.Repositories.Main;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LAStEngineer.Logistic.Infrastructure
{
  public static class InfrastructureServiceRegistration
  {

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddSingleton<IdentityDbContext>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();

      services.AddScoped<ICompanyRepository, CompanyRepository>();
      services.AddScoped<IRoleRepository, RoleRepository>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

      return services;
    }

  }
}
