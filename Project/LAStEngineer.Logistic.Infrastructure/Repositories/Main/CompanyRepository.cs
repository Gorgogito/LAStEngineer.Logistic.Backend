using Dapper;
using LAStEngineer.Logistic.Application.Interface.Persistence.Repositories.Main;
using LAStEngineer.Logistic.Domain.Entities.Main;
using LAStEngineer.Logistic.Infrastructure.Contexts;
using System.Data;

namespace LAStEngineer.Logistic.Infrastructure.Repositories.Main
{
  public class CompanyRepository : ICompanyRepository
  {


    private readonly IdentityDbContext _context;

    public CompanyRepository(IdentityDbContext context)
    { _context = context; }

    #region Métodos Síncronos

    public bool Insert(Company entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "CompanyInsert";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Ruc", entity.Ruc);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Address", entity.Address);
        parameters.Add("Agent", entity.Agent);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Web", entity.Web);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("CreatedDate", entity.CreatedDate);
        parameters.Add("CreatedBy", entity.CreatedBy);
        parameters.Add("LastModifiedDate", entity.LastModifiedDate);
        parameters.Add("LastModifiedBy", entity.LastModifiedBy);

        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public bool Update(Company entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "CompanyUpdate";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Ruc", entity.Ruc);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Address", entity.Address);
        parameters.Add("Agent", entity.Agent);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Web", entity.Web);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("CreatedDate", entity.CreatedDate);
        parameters.Add("CreatedBy", entity.CreatedBy);
        parameters.Add("LastModifiedDate", entity.LastModifiedDate);
        parameters.Add("LastModifiedBy", entity.LastModifiedBy);

        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public bool Delete(string id)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "CompanyDelete";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);
        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public Company Get(string id)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "CompanyGetByID";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);

        var customer = connection.QuerySingle<Company>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return customer;
      }
    }

    public IEnumerable<Company> GetAll()
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "CompanyList";

        var entities = connection.Query<Company>(query, commandType: CommandType.StoredProcedure);
        return entities;
      }
    }

    public IEnumerable<Company> GetAllWithPagination(int pageNumber, int pageSize)
    {
      using var connection = _context.CreateConnection();
      var query = "CompanyListWithPagination";
      var parameters = new DynamicParameters();
      parameters.Add("PageNumber", pageNumber);
      parameters.Add("PageSize", pageSize);

      var entities = connection.Query<Company>(query, param: parameters, commandType: CommandType.StoredProcedure);
      return entities;
    }

    public int Count()
    {
      using var connection = _context.CreateConnection();
      var query = "Select Count(*) from Company";

      var count = connection.ExecuteScalar<int>(query, commandType: CommandType.Text);
      return count;
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> InsertAsync(Company entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "CompanyInsert";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Ruc", entity.Ruc);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Address", entity.Address);
        parameters.Add("Agent", entity.Agent);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Web", entity.Web);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("CreatedDate", entity.CreatedDate);
        parameters.Add("CreatedBy", entity.CreatedBy);
        parameters.Add("LastModifiedDate", entity.LastModifiedDate);
        parameters.Add("LastModifiedBy", entity.LastModifiedBy);

        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<bool> UpdateAsync(Company entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "CompanyUpdate";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Ruc", entity.Ruc);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Address", entity.Address);
        parameters.Add("Agent", entity.Agent);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Web", entity.Web);
        parameters.Add("StateId", entity.StateId);
        parameters.Add("IsSystem", entity.IsSystem);
        parameters.Add("CreatedDate", entity.CreatedDate);
        parameters.Add("CreatedBy", entity.CreatedBy);
        parameters.Add("LastModifiedDate", entity.LastModifiedDate);
        parameters.Add("LastModifiedBy", entity.LastModifiedBy);

        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<bool> DeleteAsync(string id)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "CompanyDelete";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);
        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<Company> GetAsync(string id)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "CompanyGetByID";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);

        var customer = await connection.QuerySingleAsync<Company>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return customer;
      }
    }

    public async Task<IEnumerable<Company>> GetAllAsync()
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "CompanyList";

        var entities = await connection.QueryAsync<Company>(query, commandType: CommandType.StoredProcedure);
        return entities;
      }
    }

    public async Task<IEnumerable<Company>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
    {
      using var connection = _context.CreateConnection();
      var query = "CompanyListWithPagination";
      var parameters = new DynamicParameters();
      parameters.Add("PageNumber", pageNumber);
      parameters.Add("PageSize", pageSize);

      var entities = await connection.QueryAsync<Company>(query, param: parameters, commandType: CommandType.StoredProcedure);
      return entities;
    }

    public async Task<int> CountAsync()
    {
      using var connection = _context.CreateConnection();
      var query = "Select Count(*) from Company";

      var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
      return count;
    }

    #endregion

  }
}
