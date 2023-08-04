using AutoMapper;
using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Application.Interface;
using LAStEngineer.Logistic.Application.Interface.UseCases.Main;
using LAStEngineer.Logistic.Cross.Common;
using LAStEngineer.Logistic.Domain.Entities.Main;

namespace LAStEngineer.Logistic.Application.UseCases.Features.Main
{
  public class Role_x_CompanyApplication: IRole_x_CompanyApplication
  {

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Role_x_CompanyApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    #region Métodos Síncronos

    public Response<bool> Insert(Role_x_CompanyDTO entitiesDto)
    {
      var response = new Response<bool>();
      try
      {
        var entity = _mapper.Map<Role_x_Company>(entitiesDto);
        response.Data = _unitOfWork.Role_x_CompanyRepository.Insert(entity);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Message = "Registro Exitoso!!!";
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
        //response.Message = e.Message;
      }
      return response;
    }

    public Response<bool> Update(Role_x_CompanyDTO entitiesDto)
    {
      var response = new Response<bool>();
      try
      {
        var entity = _mapper.Map<Role_x_Company>(entitiesDto);
        response.Data = _unitOfWork.Role_x_CompanyRepository.Update(entity);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Message = "Actualización Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public Response<bool> Delete(string roleId, string companyId)
    {
      var response = new Response<bool>();
      try
      {
        response.Data = _unitOfWork.Role_x_CompanyRepository.Delete(roleId, companyId);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Message = "Eliminación Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public Response<Role_x_CompanyDTO> Get(string roleId, string companyId)
    {
      var response = new Response<Role_x_CompanyDTO>();
      try
      {
        var entity = _unitOfWork.Role_x_CompanyRepository.Get(roleId, companyId);
        response.Data = _mapper.Map<Role_x_CompanyDTO>(entity);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public Response<IEnumerable<Role_x_CompanyDTO>> GetAll()
    {
      var response = new Response<IEnumerable<Role_x_CompanyDTO>>();
      try
      {
        var entities = _unitOfWork.Role_x_CompanyRepository.GetAll();
        response.Data = _mapper.Map<IEnumerable<Role_x_CompanyDTO>>(entities);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public ResponsePagination<IEnumerable<Role_x_CompanyDTO>> GetAllWithPagination(int pageNumber, int pageSize)
    {
      var response = new ResponsePagination<IEnumerable<Role_x_CompanyDTO>>();
      try
      {
        var count = _unitOfWork.Role_x_CompanyRepository.Count();

        var customers = _unitOfWork.Role_x_CompanyRepository.GetAllWithPagination(pageNumber, pageSize);
        response.Data = _mapper.Map<IEnumerable<Role_x_CompanyDTO>>(customers);

        if (response.Data != null)
        {
          response.PageNumber = pageNumber;
          response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
          response.TotalCount = count;
          response.IsSuccess = true;
          response.Message = "Consulta Paginada Exitosa!!!";
        }
      }
      catch (Exception ex)
      {
        response.Message = ex.Message;
      }
      return response;
    }

    public Response<int> Count()
    {
      var response = new Response<int>();
      try
      {
        response.Data = _unitOfWork.Role_x_CompanyRepository.Count();
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    #endregion

    #region Métodos Asíncronos

    public async Task<Response<bool>> InsertAsync(Role_x_CompanyDTO entitiesDto)
    {
      var response = new Response<bool>();
      try
      {
        var entity = _mapper.Map<Role_x_Company>(entitiesDto);
        response.Data = await _unitOfWork.Role_x_CompanyRepository.InsertAsync(entity);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Message = "Registro Exitoso!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public async Task<Response<bool>> UpdateAsync(Role_x_CompanyDTO entitiesDto)
    {
      var response = new Response<bool>();
      try
      {
        var entity = _mapper.Map<Role_x_Company>(entitiesDto);
        response.Data = await _unitOfWork.Role_x_CompanyRepository.UpdateAsync(entity);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Message = "Actualización Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public async Task<Response<bool>> DeleteAsync(string roleId, string companyId)
    {
      var response = new Response<bool>();
      try
      {
        response.Data = await _unitOfWork.Role_x_CompanyRepository.DeleteAsync(roleId, companyId);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Message = "Eliminación Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public async Task<Response<Role_x_CompanyDTO>> GetAsync(string roleId, string companyId)
    {
      var response = new Response<Role_x_CompanyDTO>();
      try
      {
        var customer = await _unitOfWork.Role_x_CompanyRepository.GetAsync(roleId, companyId);
        response.Data = _mapper.Map<Role_x_CompanyDTO>(customer);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public async Task<Response<IEnumerable<Role_x_CompanyDTO>>> GetAllAsync()
    {
      var response = new Response<IEnumerable<Role_x_CompanyDTO>>();
      try
      {
        var entities = await _unitOfWork.Role_x_CompanyRepository.GetAllAsync();
        response.Data = _mapper.Map<IEnumerable<Role_x_CompanyDTO>>(entities);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    public async Task<ResponsePagination<IEnumerable<Role_x_CompanyDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
    {
      var response = new ResponsePagination<IEnumerable<Role_x_CompanyDTO>>();
      try
      {
        var count = _unitOfWork.Role_x_CompanyRepository.Count();

        var customers = _unitOfWork.Role_x_CompanyRepository.GetAllWithPagination(pageNumber, pageSize);
        response.Data = _mapper.Map<IEnumerable<Role_x_CompanyDTO>>(customers);

        if (response.Data != null)
        {
          response.PageNumber = pageNumber;
          response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
          response.TotalCount = count;
          response.IsSuccess = true;
          response.Message = "Consulta Paginada Exitosa!!!";
        }
      }
      catch (Exception ex)
      {
        response.Message = ex.Message;
      }
      return response;
    }

    public async Task<Response<int>> CountAsync()
    {
      var response = new Response<int>();
      try
      {
        //var entities = await _unitOfWork.RoleRepository.CountAsync();
        response.Data = _unitOfWork.Role_x_CompanyRepository.CountAsync().Result;
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Message = "Consulta Exitosa!!!";
        }
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }

    #endregion

  }
}
