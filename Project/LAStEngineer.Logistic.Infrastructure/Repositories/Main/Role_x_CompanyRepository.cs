using Dapper;
using LAStEngineer.Logistic.Application.Interface.Persistence;
using LAStEngineer.Logistic.Application.Interface.Persistence.Repositories.Main;
using LAStEngineer.Logistic.Domain.Entities.Main;
using LAStEngineer.Logistic.Infrastructure.Contexts;
using System.Data;

namespace LAStEngineer.Logistic.Infrastructure.Repositories.Main
{
  public class Role_x_CompanyRepository: IRole_x_CompanyRepository
  {

    private readonly IdentityDbContext _context;

    public Role_x_CompanyRepository(IdentityDbContext context)
    { _context = context; }

    #region Métodos Síncronos

    public bool Insert(Role_x_Company entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "Role_x_CompanyInsert";
        var parameters = new DynamicParameters();
        parameters.Add("RoleId", entity.RoleId);
        parameters.Add("CompanyId", entity.CompanyId);
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

    public bool Update(Role_x_Company entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "Role_x_CompanyUpdate";
        var parameters = new DynamicParameters();
        parameters.Add("RoleId", entity.RoleId);
        parameters.Add("CompanyId", entity.CompanyId);
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

    public bool Delete(string roleId, string companyId)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "Role_x_CompanyDelete";
        var parameters = new DynamicParameters();
        parameters.Add("RoleId", roleId);
        parameters.Add("CompanyId", companyId);
        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public Role_x_Company Get(string roleId, string companyId)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "Role_x_CompanyGetByID";
        var parameters = new DynamicParameters();
        parameters.Add("RoleId", roleId);
        parameters.Add("CompanyId", companyId);
        var entity = connection.QuerySingle<Role_x_Company>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public IEnumerable<Role_x_Company> GetAll()
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "Role_x_CompanyList";
        var entities = connection.Query<Role_x_Company>(query, commandType: CommandType.StoredProcedure);
        return entities;
      }
    }

    public IEnumerable<Role_x_Company> GetAllWithPagination(int pageNumber, int pageSize)
    {
      using var connection = _context.CreateConnection();
      var query = "Role_x_CompanyListWithPagination";
      var parameters = new DynamicParameters();
      parameters.Add("PageNumber", pageNumber);
      parameters.Add("PageSize", pageSize);

      var entities = connection.Query<Role_x_Company>(query, param: parameters, commandType: CommandType.StoredProcedure);
      return entities;
    }

    public int Count()
    {
      using var connection = _context.CreateConnection();
      var query = "Select Count(*) from [Role_x_Company]";

      var count = connection.ExecuteScalar<int>(query, commandType: CommandType.Text);
      return count;
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> InsertAsync(Role_x_Company entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "Role_x_CompanyInsert";
        var parameters = new DynamicParameters();
        parameters.Add("RoleId", entity.RoleId);
        parameters.Add("CompanyId", entity.CompanyId);
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

    public async Task<bool> UpdateAsync(Role_x_Company entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "Role_x_CompanyUpdate";
        var parameters = new DynamicParameters();
        parameters.Add("RoleId", entity.RoleId);
        parameters.Add("CompanyId", entity.CompanyId);
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

    public async Task<bool> DeleteAsync(string roleId, string companyId)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "Role_x_CompanyDelete";
        var parameters = new DynamicParameters();
        parameters.Add("RoleId", roleId);
        parameters.Add("CompanyId", companyId);
        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<Role_x_Company> GetAsync(string roleId, string companyId)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "Role_x_CompanyGetByID";
        var parameters = new DynamicParameters();
        parameters.Add("RoleId", roleId);
        parameters.Add("CompanyId", companyId);
        var entity = await connection.QuerySingleAsync<Role_x_Company>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public async Task<IEnumerable<Role_x_Company>> GetAllAsync()
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "Role_x_CompanyList";

        var entities = await connection.QueryAsync<Role_x_Company>(query, commandType: CommandType.StoredProcedure);
        return entities;
      }
    }

    public async Task<IEnumerable<Role_x_Company>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
    {
      using var connection = _context.CreateConnection();
      var query = "Role_x_CompanyListWithPagination";
      var parameters = new DynamicParameters();
      parameters.Add("PageNumber", pageNumber);
      parameters.Add("PageSize", pageSize);

      var entities = await connection.QueryAsync<Role_x_Company>(query, param: parameters, commandType: CommandType.StoredProcedure);
      return entities;
    }

    public async Task<int> CountAsync()
    {
      using var connection = _context.CreateConnection();
      var query = "Select Count(*) from [Role_x_Company]";

      var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
      return count;
    }

    #endregion

    bool IGenericRepository<Role_x_Company>.Delete(string id)
    {
      throw new NotImplementedException();
    }

    Role_x_Company IGenericRepository<Role_x_Company>.Get(string id)
    {
      throw new NotImplementedException();
    }

    Task<bool> IGenericRepository<Role_x_Company>.DeleteAsync(string id)
    {
      throw new NotImplementedException();
    }

    Task<Role_x_Company> IGenericRepository<Role_x_Company>.GetAsync(string id)
    {
      throw new NotImplementedException();
    }

  }
}
