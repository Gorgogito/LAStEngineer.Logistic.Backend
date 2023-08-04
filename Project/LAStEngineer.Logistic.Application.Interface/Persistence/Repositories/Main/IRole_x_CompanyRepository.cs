using LAStEngineer.Logistic.Domain.Entities.Main;

namespace LAStEngineer.Logistic.Application.Interface.Persistence.Repositories.Main
{
  public interface IRole_x_CompanyRepository : IGenericRepository<Role_x_Company>
  {
    bool Delete(string roleId, string companyId);
    Role_x_Company Get(string roleId, string companyId);
    Task<bool> DeleteAsync(string roleId, string companyId);
    Task<Role_x_Company> GetAsync(string roleId, string companyId);
  }
}
