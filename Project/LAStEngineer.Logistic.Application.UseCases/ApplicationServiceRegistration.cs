using LAStEngineer.Logistic.Application.Interface.UseCases;
using LAStEngineer.Logistic.Application.UseCases.Features.Main;
using LAStEngineer.Logistic.Application.Validator;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LAStEngineer.Logistic.Application.UseCases
{
    public static class ConfigureServices
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddAutoMapper(Assembly.GetExecutingAssembly());
      services.AddScoped<ICompanyApplication, CompanyApplication>();
      services.AddScoped<IRoleApplication, RoleApplication>();
      services.AddScoped<IUserApplication, UserApplication>();
      services.AddScoped<IAuthenticationApplication, AuthenticationApplication>();

      services.AddTransient<UsersDtoValidator>();
      return services;
    }
  }
}
