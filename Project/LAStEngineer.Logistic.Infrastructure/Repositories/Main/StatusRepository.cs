using Dapper;
using LAStEngineer.Logistic.Application.Interface.Persistence;
using LAStEngineer.Logistic.Application.Interface.Persistence.Repositories.Main;
using LAStEngineer.Logistic.Domain.Entities.Main;
using LAStEngineer.Logistic.Infrastructure.Contexts;
using System.Data;

namespace LAStEngineer.Logistic.Infrastructure.Repositories.Main
{
  public class StatusRepository : IStatusRepository
  {

    private readonly IdentityDbContext _context;

    public StatusRepository(IdentityDbContext context)
    { _context = context; }

    #region Métodos Síncronos    

    public Status Get(string id)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "StatusGetByID";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);

        var entity = connection.QuerySingle<Status>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public IEnumerable<Status> GetAll()
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "StatusList";

        var entities = connection.Query<Status>(query, commandType: CommandType.StoredProcedure);
        return entities;
      }
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<Status> GetAsync(string id)
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "StatusGetByID";
        var parameters = new DynamicParameters();
        parameters.Add("KeyId", id);

        var entity = await connection.QuerySingleAsync<Status>(query, param: parameters, commandType: CommandType.StoredProcedure);
        return entity;
      }
    }

    public async Task<IEnumerable<Status>> GetAllAsync()
    {
      using (var connection = _context.CreateConnection())
      {
        var query = "StatusList";

        var entities = await connection.QueryAsync<Status>(query, commandType: CommandType.StoredProcedure);
        return entities;
      }
    }

    #endregion

    public bool Insert(Status entity)
    { throw new NotImplementedException(); }

    public bool Update(Status entity)
    {
      throw new NotImplementedException();
    }

    public bool Delete(string id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Status> GetAllWithPagination(int pageNumber, int pageSize)
    {
      throw new NotImplementedException();
    }

    public int Count()
    {
      throw new NotImplementedException();
    }

    public Task<bool> InsertAsync(Status entity)
    {
      throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Status entity)
    {
      throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Status>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
    {
      throw new NotImplementedException();
    }

    public Task<int> CountAsync()
    {
      throw new NotImplementedException();
    }

  }
}
