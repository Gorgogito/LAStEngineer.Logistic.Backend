using Dapper;
using LAStEngineer.Logistic.Application.Interface.Persistence.Repositories.Main;
using LAStEngineer.Logistic.Domain.Entities.Main;
using LAStEngineer.Logistic.Infrastructure.Contexts;
using System.Data;

namespace LAStEngineer.Logistic.Infrastructure.Repositories.Main
{
  public class AuthenticationRepository : IAuthenticationRepository
  {

    private readonly IdentityDbContext _context;

    public AuthenticationRepository(IdentityDbContext context)
    {
      _context = context;
    }

    public User Authenticate(string userName, string password)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "UserGetByUserAndPassword";
        var parameters = new DynamicParameters();
        parameters.Add("UserName", userName);
        parameters.Add("Password", password);

        var user = connection.QuerySingle<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return user;
      }
    }

  }
}
