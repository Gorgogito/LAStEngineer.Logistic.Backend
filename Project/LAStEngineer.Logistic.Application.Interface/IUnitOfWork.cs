using LAStEngineer.Logistic.Application.Interface.Persistence.Repositories.Main;

namespace LAStEngineer.Logistic.Application.Interface
{
  public interface IUnitOfWork : IDisposable
  {

    IAuthenticationRepository AuthenticationRepository { get; }
    IStatusRepository StatusRepository { get; }
    ICompanyRepository CompanyRepository { get; }
    IRoleRepository RoleRepository { get; }
    IUserRepository UserRepository { get; }
    IRole_x_CompanyRepository Role_x_CompanyRepository { get; }

  }
}