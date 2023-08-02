using LAStEngineer.Logistic.Application.DTO.Common;
using LAStEngineer.Logistic.Application.Interface.Persistence;
using LAStEngineer.Logistic.Application.Interface.Persistence.Repositories.Main;
using LAStEngineer.Logistic.Domain.Common;

namespace LAStEngineer.Logistic.Application.Interface
{
  public interface IUnitOfWork : IDisposable
  {

    ICompanyRepository CompanyRepository { get; }
    IRoleRepository RoleRepository { get; }
    IUserRepository UserRepository { get; }

  }
}