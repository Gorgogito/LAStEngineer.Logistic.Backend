using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace LAStEngineer.Logistic.Infrastructure.Contexts
{
  public class IdentityDbContext
  {
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public IdentityDbContext(IConfiguration configuration)
    {
      _configuration = configuration;
      _connectionString = configuration.GetConnectionString("Identity");
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

  }
}
