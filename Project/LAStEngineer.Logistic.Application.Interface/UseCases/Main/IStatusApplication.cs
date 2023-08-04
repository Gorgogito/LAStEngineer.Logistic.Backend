using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Cross.Common;

namespace LAStEngineer.Logistic.Application.Interface.UseCases.Main
{
    public interface IStatusApplication
    {

    #region Métodos Síncronos

    //Response<bool> Insert(StatusDTO entityDto);
    //Response<bool> Update(StatusDTO entityDto);
    //Response<bool> Delete(string Id);
    Response<StatusDTO> Get(string Id);
    Response<IEnumerable<StatusDTO>> GetAll();
    //ResponsePagination<IEnumerable<StatusDTO>> GetAllWithPagination(int pageNumber, int pageSize);
    
    #endregion

    #region Métodos Asíncronos

    //Task<Response<bool>> InsertAsync(StatusDTO entityDto);
    //Task<Response<bool>> UpdateAsync(StatusDTO entityDto);
    //Task<Response<bool>> DeleteAsync(string entityDto);
    Task<Response<StatusDTO>> GetAsync(string Id);
    Task<Response<IEnumerable<StatusDTO>>> GetAllAsync();
    //Task<ResponsePagination<IEnumerable<StatusDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
    
    #endregion

  }
}