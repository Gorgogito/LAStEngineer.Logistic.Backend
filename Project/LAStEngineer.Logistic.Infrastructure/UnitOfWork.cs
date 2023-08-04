using LAStEngineer.Logistic.Application.Interface;
using LAStEngineer.Logistic.Application.Interface.Persistence.Repositories.Main;
using LAStEngineer.Logistic.Infrastructure.Contexts;
using LAStEngineer.Logistic.Infrastructure.Persistence.Persistence.Repositories.Main;
using LAStEngineer.Logistic.Infrastructure.Repositories.Main;
using System.Collections;

namespace LAStEngineer.Logistic.Infrastructure
{
  public class UnitOfWork : IUnitOfWork
  {

    private Hashtable _repositories;
    private readonly IdentityDbContext _context;

    private IAuthenticationRepository _authenticationRepository;
    private IStatusRepository _statusRepository;
    private ICompanyRepository _companyRepository;
    private IRoleRepository _roleRepository;
    private IUserRepository _userRepository;
    private IRole_x_CompanyRepository _role_x_companyRepository;

    public UnitOfWork(IdentityDbContext context)
    { _context = context; }

    public void Dispose()
    { System.GC.SuppressFinalize(this); }

    public IdentityDbContext DbContextIdentity => _context;

    public IAuthenticationRepository AuthenticationRepository => _authenticationRepository = new AuthenticationRepository(_context);
    public IStatusRepository StatusRepository => _statusRepository = new StatusRepository(_context);
    public ICompanyRepository CompanyRepository => _companyRepository = new CompanyRepository(_context);
    public IRoleRepository RoleRepository => _roleRepository = new RoleRepository(_context);
    public IUserRepository UserRepository => _userRepository = new UserRepository(_context);
    public IRole_x_CompanyRepository Role_x_CompanyRepository => _role_x_companyRepository = new Role_x_CompanyRepository(_context);

  }

}
