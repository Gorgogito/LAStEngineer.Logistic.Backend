using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Cross.Common;

namespace LAStEngineer.Logistic.Application.Interface.UseCases
{
  public interface IUserApplication
  {

    #region Métodos Síncronos

    Response<bool> Insert(UserDTO entityDto);
    Response<bool> Update(UserDTO entityDto);
    Response<bool> Delete(string Id);
    Response<UserDTO> Get(string Id);
    Response<IEnumerable<UserDTO>> GetAll();
    ResponsePagination<IEnumerable<UserDTO>> GetAllWithPagination(int pageNumber, int pageSize);
    
    #endregion

    #region Métodos Asíncronos

    Task<Response<bool>> InsertAsync(UserDTO entityDto);
    Task<Response<bool>> UpdateAsync(UserDTO entityDto);
    Task<Response<bool>> DeleteAsync(string entityDto);
    Task<Response<UserDTO>> GetAsync(string Id);
    Task<Response<IEnumerable<UserDTO>>> GetAllAsync();
    Task<ResponsePagination<IEnumerable<UserDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
    
    #endregion

  }
}
