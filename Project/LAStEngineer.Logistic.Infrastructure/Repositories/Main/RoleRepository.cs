using Dapper;
using LAStEngineer.Logistic.Application.Interface.Persistence.Repositories.Main;
using LAStEngineer.Logistic.Domain.Entities.Main;
using LAStEngineer.Logistic.Infrastructure.Contexts;
using System.Data;

namespace LAStEngineer.Logistic.Infrastructure.Persistence.Persistence.Repositories.Main
{
  public class RoleRepository : IRoleRepository
  {

    private readonly IdentityDbContext _context;

    public RoleRepository(IdentityDbContext context)
    { _context = context; }

    #region Métodos Síncronos

    public bool Insert(Role entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "RoleInsert";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Name", entity.Name);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
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

    public bool Update(Role entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "RoleUpdate";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Name", entity.Name);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
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
        var query = "RoleDelete";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);
        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public Role Get(string id)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "RoleGetByID";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);

        var entity = connection.QuerySingle<Role>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public IEnumerable<Role> GetAll()
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "RoleList";

        var entities = connection.Query<Role>(query, commandType: CommandType.StoredProcedure);
        return entities;
      }
    }

    public IEnumerable<Role> GetAllWithPagination(int pageNumber, int pageSize)
    {
      using var connection = _context.CreateConnection();
      var query = "RoleListWithPagination";
      var parameters = new DynamicParameters();
      parameters.Add("PageNumber", pageNumber);
      parameters.Add("PageSize", pageSize);

      var entities = connection.Query<Role>(query, param: parameters, commandType: CommandType.StoredProcedure);
      return entities;
    }

    public int Count()
    {
      using var connection = _context.CreateConnection();
      var query = "Select Count(*) from [Role]";

      var count = connection.ExecuteScalar<int>(query, commandType: CommandType.Text);
      return count;
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> InsertAsync(Role entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "RoleInsert";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Name", entity.Name);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
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

    public async Task<bool> UpdateAsync(Role entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "RoleUpdate";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("Name", entity.Name);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
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
        var query = "RoleDelete";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);
        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<Role> GetAsync(string id)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "RoleGetByID";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);

        var entity = await connection.QuerySingleAsync<Role>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "RoleList";

        var entities = await connection.QueryAsync<Role>(query, commandType: CommandType.StoredProcedure);
        return entities;
      }
    }

    public async Task<IEnumerable<Role>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
    {
      using var connection = _context.CreateConnection();
      var query = "RoleListWithPagination";
      var parameters = new DynamicParameters();
      parameters.Add("PageNumber", pageNumber);
      parameters.Add("PageSize", pageSize);

      var entities = await connection.QueryAsync<Role>(query, param: parameters, commandType: CommandType.StoredProcedure);
      return entities;
    }

    public async Task<int> CountAsync()
    {
      using var connection = _context.CreateConnection();
      var query = "Select Count(*) from [Role]";

      var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
      return count;
    }

    #endregion

  }
}