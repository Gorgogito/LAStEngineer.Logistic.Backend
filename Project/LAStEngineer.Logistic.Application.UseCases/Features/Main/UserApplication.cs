using AutoMapper;
using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Application.Interface.UseCases;
using LAStEngineer.Logistic.Application.Interface;
using LAStEngineer.Logistic.Cross.Common;
using LAStEngineer.Logistic.Domain.Entities.Main;

namespace LAStEngineer.Logistic.Application.UseCases.Features.Main
{
  public class UserApplication : IUserApplication
  {

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    #region Métodos Síncronos

    public Response<bool> Insert(UserDTO entitiesDto)
    {
      var response = new Response<bool>();
      try
      {
        var entity = _mapper.Map<User>(entitiesDto);
        response.Data = _unitOfWork.UserRepository.Insert(entity);
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

    public Response<bool> Update(UserDTO entitiesDto)
    {
      var response = new Response<bool>();
      try
      {
        var entity = _mapper.Map<User>(entitiesDto);
        response.Data = _unitOfWork.UserRepository.Update(entity);
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
        response.Data = _unitOfWork.UserRepository.Delete(KeyId);
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

    public Response<UserDTO> Get(string KeyId)
    {
      var response = new Response<UserDTO>();
      try
      {
        var entity = _unitOfWork.UserRepository.Get(KeyId);
        response.Data = _mapper.Map<UserDTO>(entity);
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

    public Response<IEnumerable<UserDTO>> GetAll()
    {
      var response = new Response<IEnumerable<UserDTO>>();
      try
      {
        var entities = _unitOfWork.UserRepository.GetAll();
        response.Data = _mapper.Map<IEnumerable<UserDTO>>(entities);
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

    public ResponsePagination<IEnumerable<UserDTO>> GetAllWithPagination(int pageNumber, int pageSize)
    {
      var response = new ResponsePagination<IEnumerable<UserDTO>>();
      try
      {
        var count = _unitOfWork.UserRepository.Count();

        var customers = _unitOfWork.UserRepository.GetAllWithPagination(pageNumber, pageSize);
        response.Data = _mapper.Map<IEnumerable<UserDTO>>(customers);

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
        response.Data = _unitOfWork.UserRepository.Count();
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

    public async Task<Response<bool>> InsertAsync(UserDTO entitiesDto)
    {
      var response = new Response<bool>();
      try
      {
        var entity = _mapper.Map<User>(entitiesDto);
        response.Data = await _unitOfWork.UserRepository.InsertAsync(entity);
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

    public async Task<Response<bool>> UpdateAsync(UserDTO entitiesDto)
    {
      var response = new Response<bool>();
      try
      {
        var entity = _mapper.Map<User>(entitiesDto);
        response.Data = await _unitOfWork.UserRepository.UpdateAsync(entity);
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
        response.Data = await _unitOfWork.UserRepository.DeleteAsync(KeyId);
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

    public async Task<Response<UserDTO>> GetAsync(string KeyId)
    {
      var response = new Response<UserDTO>();
      try
      {
        var customer = await _unitOfWork.UserRepository.GetAsync(KeyId);
        response.Data = _mapper.Map<UserDTO>(customer);
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

    public async Task<Response<IEnumerable<UserDTO>>> GetAllAsync()
    {
      var response = new Response<IEnumerable<UserDTO>>();
      try
      {
        var entities = await _unitOfWork.UserRepository.GetAllAsync();
        response.Data = _mapper.Map<IEnumerable<UserDTO>>(entities);
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

    public async Task<ResponsePagination<IEnumerable<UserDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
    {
      var response = new ResponsePagination<IEnumerable<UserDTO>>();
      try
      {
        var count = _unitOfWork.UserRepository.Count();

        var customers = _unitOfWork.UserRepository.GetAllWithPagination(pageNumber, pageSize);
        response.Data = _mapper.Map<IEnumerable<UserDTO>>(customers);

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
        response.Data = _unitOfWork.UserRepository.CountAsync().Result;
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