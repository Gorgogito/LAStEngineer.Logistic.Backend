using AutoMapper;
using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Application.Interface;
using LAStEngineer.Logistic.Domain.Entities.Main;
using LAStEngineer.Logistic.Cross.Common;
using LAStEngineer.Logistic.Application.Interface.UseCases;

namespace LAStEngineer.Logistic.Application.UseCases.Features.Main
{
    public class CompanyApplication : ICompanyApplication
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(CompanyDTO entitiesDto)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Company>(entitiesDto);
                response.Data = _unitOfWork.CompanyRepository.Insert(entity);
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

        public Response<bool> Update(CompanyDTO entitiesDto)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Company>(entitiesDto);
                response.Data = _unitOfWork.CompanyRepository.Update(entity);
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
                response.Data = _unitOfWork.CompanyRepository.Delete(KeyId);
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

        public Response<CompanyDTO> Get(string KeyId)
        {
            var response = new Response<CompanyDTO>();
            try
            {
                var entity = _unitOfWork.CompanyRepository.Get(KeyId);
                response.Data = _mapper.Map<CompanyDTO>(entity);
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

        public Response<IEnumerable<CompanyDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CompanyDTO>>();
            try
            {
                var entities = _unitOfWork.CompanyRepository.GetAll();
                response.Data = _mapper.Map<IEnumerable<CompanyDTO>>(entities);
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

        public ResponsePagination<IEnumerable<CompanyDTO>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CompanyDTO>>();
            try
            {
                var count = _unitOfWork.CompanyRepository.Count();

                var customers = _unitOfWork.CompanyRepository.GetAllWithPagination(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CompanyDTO>>(customers);

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
                var entities = _unitOfWork.CompanyRepository.Count();
                response.Data = _unitOfWork.CompanyRepository.Count();
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

        public async Task<Response<bool>> InsertAsync(CompanyDTO entitiesDto)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Company>(entitiesDto);
                response.Data = await _unitOfWork.CompanyRepository.InsertAsync(entity);
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

        public async Task<Response<bool>> UpdateAsync(CompanyDTO entitiesDto)
        {
            var response = new Response<bool>();
            try
            {
                var entity = _mapper.Map<Company>(entitiesDto);
                response.Data = await _unitOfWork.CompanyRepository.UpdateAsync(entity);
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
                response.Data = await _unitOfWork.CompanyRepository.DeleteAsync(KeyId);
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

        public async Task<Response<CompanyDTO>> GetAsync(string KeyId)
        {
            var response = new Response<CompanyDTO>();
            try
            {
                var customer = await _unitOfWork.CompanyRepository.GetAsync(KeyId);
                response.Data = _mapper.Map<CompanyDTO>(customer);
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

        public async Task<Response<IEnumerable<CompanyDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CompanyDTO>>();
            try
            {
                var entities = await _unitOfWork.CompanyRepository.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CompanyDTO>>(entities);
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

        public async Task<ResponsePagination<IEnumerable<CompanyDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CompanyDTO>>();
            try
            {
                var count = _unitOfWork.CompanyRepository.Count();

                var customers = _unitOfWork.CompanyRepository.GetAllWithPagination(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CompanyDTO>>(customers);

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
                var entities = await _unitOfWork.CompanyRepository.CountAsync();
                response.Data = _unitOfWork.CompanyRepository.CountAsync().Result;
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
