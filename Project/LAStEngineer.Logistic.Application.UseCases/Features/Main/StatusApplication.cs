using AutoMapper;
using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Application.Interface;
using LAStEngineer.Logistic.Application.Interface.UseCases.Main;
using LAStEngineer.Logistic.Cross.Common;
using LAStEngineer.Logistic.Domain.Entities.Main;

namespace LAStEngineer.Logistic.Application.UseCases.Features.Main
{
  public class StatusApplication : IStatusApplication
  {

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StatusApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    #region Métodos Síncronos

    //public Response<bool> Insert(StatusDTO entitiesDto)
    //{
    //  var response = new Response<bool>();
    //  try
    //  {
    //    var entity = _mapper.Map<Status>(entitiesDto);
    //    response.Data = _unitOfWork.StatusRepository.Insert(entity);
    //    if (response.Data)
    //    {
    //      response.IsSuccess = true;
    //      response.Message = "Registro Exitoso!!!";
    //    }
    //  }
    //  catch (Exception e)
    //  {
    //    throw new Exception(e.Message);
    //    //response.Message = e.Message;
    //  }
    //  return response;
    //}

    //public Response<bool> Update(StatusDTO entitiesDto)
    //{
    //  var response = new Response<bool>();
    //  try
    //  {
    //    var entity = _mapper.Map<Status>(entitiesDto);
    //    response.Data = _unitOfWork.StatusRepository.Update(entity);
    //    if (response.Data)
    //    {
    //      response.IsSuccess = true;
    //      response.Message = "Actualización Exitosa!!!";
    //    }
    //  }
    //  catch (Exception e)
    //  {
    //    response.Message = e.Message;
    //  }
    //  return response;
    //}

    //public Response<bool> Delete(string KeyId)
    //{
    //  var response = new Response<bool>();
    //  try
    //  {
    //    response.Data = _unitOfWork.StatusRepository.Delete(KeyId);
    //    if (response.Data)
    //    {
    //      response.IsSuccess = true;
    //      response.Message = "Eliminación Exitosa!!!";
    //    }
    //  }
    //  catch (Exception e)
    //  {
    //    response.Message = e.Message;
    //  }
    //  return response;
    //}

    public Response<StatusDTO> Get(string KeyId)
    {
      var response = new Response<StatusDTO>();
      try
      {
        var entity = _unitOfWork.StatusRepository.Get(KeyId);
        response.Data = _mapper.Map<StatusDTO>(entity);
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

    public Response<IEnumerable<StatusDTO>> GetAll()
    {
      var response = new Response<IEnumerable<StatusDTO>>();
      try
      {
        var entities = _unitOfWork.StatusRepository.GetAll();
        response.Data = _mapper.Map<IEnumerable<StatusDTO>>(entities);
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

    //public ResponsePagination<IEnumerable<StatusDTO>> GetAllWithPagination(int pageNumber, int pageSize)
    //{
    //  var response = new ResponsePagination<IEnumerable<StatusDTO>>();
    //  try
    //  {
    //    var count = _unitOfWork.StatusRepository.Count();

    //    var customers = _unitOfWork.RoleRepository.GetAllWithPagination(pageNumber, pageSize);
    //    response.Data = _mapper.Map<IEnumerable<StatusDTO>>(customers);

    //    if (response.Data != null)
    //    {
    //      response.PageNumber = pageNumber;
    //      response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    //      response.TotalCount = count;
    //      response.IsSuccess = true;
    //      response.Message = "Consulta Paginada Exitosa!!!";
    //    }
    //  }
    //  catch (Exception ex)
    //  {
    //    response.Message = ex.Message;
    //  }
    //  return response;
    //}

    //public Response<int> Count()
    //{
    //  var response = new Response<int>();
    //  try
    //  {
    //    response.Data = _unitOfWork.StatusRepository.Count();
    //    if (response.Data != null)
    //    {
    //      response.IsSuccess = true;
    //      response.Message = "Consulta Exitosa!!!";
    //    }
    //  }
    //  catch (Exception e)
    //  {
    //    response.Message = e.Message;
    //  }
    //  return response;
    //}

    #endregion

    #region Métodos Asíncronos

    //public async Task<Response<bool>> InsertAsync(StatusDTO entitiesDto)
    //{
    //  var response = new Response<bool>();
    //  try
    //  {
    //    var entity = _mapper.Map<Status>(entitiesDto);
    //    response.Data = await _unitOfWork.StatusRepository.InsertAsync(entity);
    //    if (response.Data)
    //    {
    //      response.IsSuccess = true;
    //      response.Message = "Registro Exitoso!!!";
    //    }
    //  }
    //  catch (Exception e)
    //  {
    //    response.Message = e.Message;
    //  }
    //  return response;
    //}

    //public async Task<Response<bool>> UpdateAsync(StatusDTO entitiesDto)
    //{
    //  var response = new Response<bool>();
    //  try
    //  {
    //    var entity = _mapper.Map<Status>(entitiesDto);
    //    response.Data = await _unitOfWork.StatusRepository.UpdateAsync(entity);
    //    if (response.Data)
    //    {
    //      response.IsSuccess = true;
    //      response.Message = "Actualización Exitosa!!!";
    //    }
    //  }
    //  catch (Exception e)
    //  {
    //    response.Message = e.Message;
    //  }
    //  return response;
    //}

    //public async Task<Response<bool>> DeleteAsync(string KeyId)
    //{
    //  var response = new Response<bool>();
    //  try
    //  {
    //    response.Data = await _unitOfWork.StatusRepository.DeleteAsync(KeyId);
    //    if (response.Data)
    //    {
    //      response.IsSuccess = true;
    //      response.Message = "Eliminación Exitosa!!!";
    //    }
    //  }
    //  catch (Exception e)
    //  {
    //    response.Message = e.Message;
    //  }
    //  return response;
    //}

    public async Task<Response<StatusDTO>> GetAsync(string KeyId)
    {
      var response = new Response<StatusDTO>();
      try
      {
        var customer = await _unitOfWork.StatusRepository.GetAsync(KeyId);
        response.Data = _mapper.Map<StatusDTO>(customer);
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

    public async Task<Response<IEnumerable<StatusDTO>>> GetAllAsync()
    {
      var response = new Response<IEnumerable<StatusDTO>>();
      try
      {
        var entities = await _unitOfWork.StatusRepository.GetAllAsync();
        response.Data = _mapper.Map<IEnumerable<StatusDTO>>(entities);
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

    //public async Task<ResponsePagination<IEnumerable<StatusDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
    //{
    //  var response = new ResponsePagination<IEnumerable<StatusDTO>>();
    //  try
    //  {
    //    var count = _unitOfWork.StatusRepository.Count();

    //    var customers = _unitOfWork.StatusRepository.GetAllWithPagination(pageNumber, pageSize);
    //    response.Data = _mapper.Map<IEnumerable<StatusDTO>>(customers);

    //    if (response.Data != null)
    //    {
    //      response.PageNumber = pageNumber;
    //      response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    //      response.TotalCount = count;
    //      response.IsSuccess = true;
    //      response.Message = "Consulta Paginada Exitosa!!!";
    //    }
    //  }
    //  catch (Exception ex)
    //  {
    //    response.Message = ex.Message;
    //  }
    //  return response;
    //}

    //public async Task<Response<int>> CountAsync()
    //{
    //  var response = new Response<int>();
    //  try
    //  {
    //    //var entities = await _unitOfWork.RoleRepository.CountAsync();
    //    response.Data = _unitOfWork.StatusRepository.CountAsync().Result;
    //    if (response.Data != null)
    //    {
    //      response.IsSuccess = true;
    //      response.Message = "Consulta Exitosa!!!";
    //    }
    //  }
    //  catch (Exception e)
    //  {
    //    response.Message = e.Message;
    //  }
    //  return response;
    //}

    #endregion

  }
}
