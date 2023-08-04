using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Cross.Common;

namespace LAStEngineer.Logistic.Application.Interface.UseCases.Main
{
  public interface IRoleApplication
  {

    #region Métodos Síncronos

    Response<bool> Insert(RoleDTO entityDto);
    Response<bool> Update(RoleDTO entityDto);
    Response<bool> Delete(string Id);

    Response<RoleDTO> Get(string Id);
    Response<IEnumerable<RoleDTO>> GetAll();
    ResponsePagination<IEnumerable<RoleDTO>> GetAllWithPagination(int pageNumber, int pageSize);
    #endregion

    #region Métodos Asíncronos
    Task<Response<bool>> InsertAsync(RoleDTO entityDto);
    Task<Response<bool>> UpdateAsync(RoleDTO entityDto);
    Task<Response<bool>> DeleteAsync(string entityDto);

    Task<Response<RoleDTO>> GetAsync(string Id);
    Task<Response<IEnumerable<RoleDTO>>> GetAllAsync();
    Task<ResponsePagination<IEnumerable<RoleDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
    #endregion

  }
}
