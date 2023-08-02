using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Cross.Common;

namespace LAStEngineer.Logistic.Application.Interface.UseCases
{
    public interface ICompanyApplication
    {

        #region Métodos Síncronos

        Response<bool> Insert(CompanyDTO entityDto);
        Response<bool> Update(CompanyDTO entityDto);
        Response<bool> Delete(string Id);

        Response<CompanyDTO> Get(string Id);
        Response<IEnumerable<CompanyDTO>> GetAll();
        ResponsePagination<IEnumerable<CompanyDTO>> GetAllWithPagination(int pageNumber, int pageSize);
        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(CompanyDTO entityDto);
        Task<Response<bool>> UpdateAsync(CompanyDTO entityDto);
        Task<Response<bool>> DeleteAsync(string entityDto);

        Task<Response<CompanyDTO>> GetAsync(string Id);
        Task<Response<IEnumerable<CompanyDTO>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<CompanyDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        #endregion

    }
}
