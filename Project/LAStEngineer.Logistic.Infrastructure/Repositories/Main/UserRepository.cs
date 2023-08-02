using Dapper;
using LAStEngineer.Logistic.Application.Interface.Persistence.Repositories.Main;
using LAStEngineer.Logistic.Domain.Entities.Main;
using LAStEngineer.Logistic.Infrastructure.Contexts;
using System.Data;

namespace LAStEngineer.Logistic.Infrastructure.Repositories.Main
{
  public class UserRepository : IUserRepository
  {

    private readonly IdentityDbContext _context;

    public UserRepository(IdentityDbContext context)
    { _context = context; }

    #region Métodos Síncronos

    public bool Insert(User entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "UserInsert";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("UserName", entity.UserName);
        parameters.Add("Password", entity.Password);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Names", entity.Names);
        parameters.Add("Surnames", entity.Surnames);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Image", entity.Image);
        parameters.Add("Token", entity.Token);
        parameters.Add("RoleId", entity.RoleId);
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

    public bool Update(User entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "UserUpdate";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("UserName", entity.UserName);
        parameters.Add("Password", entity.Password);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Names", entity.Names);
        parameters.Add("Surnames", entity.Surnames);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Image", entity.Image);
        parameters.Add("Token", entity.Token);
        parameters.Add("RoleId", entity.RoleId);
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
        var query = "UserDelete";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);
        var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public User Get(string id)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "UserGetByID";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);

        var entity = connection.QuerySingle<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public IEnumerable<User> GetAll()
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "UserList";

        var entities = connection.Query<User>(query, commandType: CommandType.StoredProcedure);
        return entities;
      }
    }

    public IEnumerable<User> GetAllWithPagination(int pageNumber, int pageSize)
    {
      using var connection = _context.CreateConnection();
      var query = "RoleListWithPagination";
      var parameters = new DynamicParameters();
      parameters.Add("PageNumber", pageNumber);
      parameters.Add("PageSize", pageSize);

      var entities = connection.Query<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
      return entities;
    }

    public int Count()
    {
      using var connection = _context.CreateConnection();
      var query = "Select Count(*) from [User]";

      var count = connection.ExecuteScalar<int>(query, commandType: CommandType.Text);
      return count;
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<bool> InsertAsync(User entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "UserInsert";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("UserName", entity.UserName);
        parameters.Add("Password", entity.Password);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Names", entity.Names);
        parameters.Add("Surnames", entity.Surnames);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Image", entity.Image);
        parameters.Add("Token", entity.Token);
        parameters.Add("RoleId", entity.RoleId);
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

    public async Task<bool> UpdateAsync(User entity)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "UserUpdate";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", entity.KeyId);
        parameters.Add("UserName", entity.UserName);
        parameters.Add("Password", entity.Password);
        parameters.Add("Description", entity.Description);
        parameters.Add("Observation", entity.Observation);
        parameters.Add("Names", entity.Names);
        parameters.Add("Surnames", entity.Surnames);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("EMail", entity.EMail);
        parameters.Add("Image", entity.Image);
        parameters.Add("Token", entity.Token);
        parameters.Add("RoleId", entity.RoleId);
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
        var query = "UserDelete";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);
        var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
      }
    }

    public async Task<User> GetAsync(string id)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "UserGetByID";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);

        var entity = await connection.QuerySingleAsync<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "UserList";

        var entities = await connection.QueryAsync<User>(query, commandType: CommandType.StoredProcedure);
        return entities;
      }
    }

    public async Task<IEnumerable<User>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
    {
      using var connection = _context.CreateConnection();
      var query = "UserListWithPagination";
      var parameters = new DynamicParameters();
      parameters.Add("PageNumber", pageNumber);
      parameters.Add("PageSize", pageSize);

      var entities = await connection.QueryAsync<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
      return entities;
    }

    public async Task<int> CountAsync()
    {
      using var connection = _context.CreateConnection();
      var query = "Select Count(*) from [User]";

      var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
      return count;
    }

    #endregion

  }
}