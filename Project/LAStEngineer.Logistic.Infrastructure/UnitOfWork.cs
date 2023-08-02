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

    private ICompanyRepository _companyRepository;
    private IRoleRepository _roleRepository;
    //private IUserRepository _userRepository;

    public ICompanyRepository CompanyRepository => _companyRepository = new CompanyRepository(_context);
    public IRoleRepository RoleRepository => _roleRepository = new RoleRepository(_context);
    //public IUserRepository UserRepository => _userRepository = new UserRepository(_context);

    public UnitOfWork(IdentityDbContext context)
    { _context = context; }

    public IdentityDbContext DbContextIdentity => _context;

    //public async Task<int> Complete()
    //{ return await _context.SaveChangesAsync(); }

    public void Dispose()
    { System.GC.SuppressFinalize(this); }

    //public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
    //{
    //  if (_repositories == null)
    //  { _repositories = new Hashtable(); }
    //  var type = typeof(TEntity);
    //  if (!_repositories.ContainsKey(type))
    //  {
    //    var repositoryType = typeof(RepositoryBase<>);
    //    var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)));
    //    _repositories.Add(type, repositoryInstance);
    //  }
    //  return (IAsyncRepository<TEntity>)_repositories[type];
    //}

  }

}
