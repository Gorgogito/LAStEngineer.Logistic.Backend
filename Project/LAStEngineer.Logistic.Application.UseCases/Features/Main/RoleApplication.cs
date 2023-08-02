using AutoMapper;
using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Application.Interface;
using LAStEngineer.Logistic.Application.Interface.UseCases;
using LAStEngineer.Logistic.Cross.Common;
using LAStEngineer.Logistic.Domain.Entities.Main;

namespace LAStEngineer.Logistic.Application.UseCases.Features.Main
{
  public class RoleApplication : IRoleApplication
  {

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RoleApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    #region Métodos Síncronos

    public Response<bool> Insert(RoleDTO entitiesDto)
    {
      var response = new Response<bool>();
      try
      {
        var entity = _mapper.Map<Role>(entitiesDto);
        response.Data = _unitOfWork.RoleRepository.Insert(entity);
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

    public Response<bool> Update(RoleDTO entitiesDto)
    {
      var response = new Response<bool>();
      try
      {
        var entity = _mapper.Map<Role>(entitiesDto);
        response.Data = _unitOfWork.RoleRepository.Update(entity);
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

    public Response<bool> Delete(string KeyId)
    {
      var response = new Response<bool>();
      try
      {
        response.Data = _unitOfWork.RoleRepository.Delete(KeyId);
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

    public Response<RoleDTO> Get(string KeyId)
    {
      var response = new Response<RoleDTO>();
      try
      {
        var entity = _unitOfWork.RoleRepository.Get(KeyId);
        response.Data = _mapper.Map<RoleDTO>(entity);
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

    public Response<IEnumerable<RoleDTO>> GetAll()
    {
      var response = new Response<IEnumerable<RoleDTO>>();
      try
      {
        var entities = _unitOfWork.RoleRepository.GetAll();
        response.Data = _mapper.Map<IEnumerable<RoleDTO>>(entities);
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

    public ResponsePagination<IEnumerable<RoleDTO>> GetAllWithPagination(int pageNumber, int pageSize)
    {
      var response = new ResponsePagination<IEnumerable<RoleDTO>>();
      try
      {
        var count = _unitOfWork.RoleRepository.Count();

        var customers = _unitOfWork.RoleRepository.GetAllWithPagination(pageNumber, pageSize);
        response.Data = _mapper.Map<IEnumerable<RoleDTO>>(customers);

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
        response.Data = _unitOfWork.RoleRepository.Count();
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

    public async Task<Response<bool>> InsertAsync(RoleDTO entitiesDto)
    {
      var response = new Response<bool>();
      try
      {
        var entity = _mapper.Map<Role>(entitiesDto);
        response.Data = await _unitOfWork.RoleRepository.InsertAsync(entity);
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

    public async Task<Response<bool>> UpdateAsync(RoleDTO entitiesDto)
    {
      var response = new Response<bool>();
      try
      {
        var entity = _mapper.Map<Role>(entitiesDto);
        response.Data = await _unitOfWork.RoleRepository.UpdateAsync(entity);
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

    public async Task<Response<bool>> DeleteAsync(string KeyId)
    {
      var response = new Response<bool>();
      try
      {
        response.Data = await _unitOfWork.RoleRepository.DeleteAsync(KeyId);
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

    public async Task<Response<RoleDTO>> GetAsync(string KeyId)
    {
      var response = new Response<RoleDTO>();
      try
      {
        var customer = await _unitOfWork.RoleRepository.GetAsync(KeyId);
        response.Data = _mapper.Map<RoleDTO>(customer);
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

    public async Task<Response<IEnumerable<RoleDTO>>> GetAllAsync()
    {
      var response = new Response<IEnumerable<RoleDTO>>();
      try
      {
        var entities = await _unitOfWork.RoleRepository.GetAllAsync();
        response.Data = _mapper.Map<IEnumerable<RoleDTO>>(entities);
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

    public async Task<ResponsePagination<IEnumerable<RoleDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
    {
      var response = new ResponsePagination<IEnumerable<RoleDTO>>();
      try
      {
        var count = _unitOfWork.RoleRepository.Count();

        var customers = _unitOfWork.RoleRepository.GetAllWithPagination(pageNumber, pageSize);
        response.Data = _mapper.Map<IEnumerable<RoleDTO>>(customers);

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
        response.Data = _unitOfWork.RoleRepository.CountAsync().Result;
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