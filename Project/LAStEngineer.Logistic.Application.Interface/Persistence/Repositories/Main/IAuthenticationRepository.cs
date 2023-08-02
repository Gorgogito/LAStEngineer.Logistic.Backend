using LAStEngineer.Logistic.Domain.Entities.Main;

namespace LAStEngineer.Logistic.Application.Interface.Persistence.Repositories.Main
{

  public interface IAuthenticationRepository //: IGenericRepository<User>
  {

    User Authenticate(string username, string password);

  }

}