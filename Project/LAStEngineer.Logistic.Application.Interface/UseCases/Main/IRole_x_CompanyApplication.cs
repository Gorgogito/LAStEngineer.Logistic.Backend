using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Cross.Common;

namespace LAStEngineer.Logistic.Application.Interface.UseCases.Main
{
  public interface IRole_x_CompanyApplication
  {

    #region Métodos Síncronos

    Response<bool> Insert(Role_x_CompanyDTO entityDto);
    Response<bool> Update(Role_x_CompanyDTO entityDto);
    Response<bool> Delete(string roleId, string companyId);
    Response<Role_x_CompanyDTO> Get(string roleId, string companyId);
    Response<IEnumerable<Role_x_CompanyDTO>> GetAll();
    ResponsePagination<IEnumerable<Role_x_CompanyDTO>> GetAllWithPagination(int pageNumber, int pageSize);
    
    #endregion

    #region Métodos Asíncronos

    Task<Response<bool>> InsertAsync(Role_x_CompanyDTO entityDto);
    Task<Response<bool>> UpdateAsync(Role_x_CompanyDTO entityDto);
    Task<Response<bool>> DeleteAsync(string roleId, string companyId);
    Task<Response<Role_x_CompanyDTO>> GetAsync(string roleId, string companyId);
    Task<Response<IEnumerable<Role_x_CompanyDTO>>> GetAllAsync();
    Task<ResponsePagination<IEnumerable<Role_x_CompanyDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
   
    #endregion

  }
}
