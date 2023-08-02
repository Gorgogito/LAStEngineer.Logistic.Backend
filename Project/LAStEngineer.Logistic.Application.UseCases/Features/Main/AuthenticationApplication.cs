using AutoMapper;
using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Application.Interface;
using LAStEngineer.Logistic.Application.Interface.UseCases;
using LAStEngineer.Logistic.Application.Validator;
using LAStEngineer.Logistic.Cross.Common;

namespace LAStEngineer.Logistic.Application.UseCases.Features.Main
{
  public class AuthenticationApplication : IAuthenticationApplication
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UsersDtoValidator _usersDtoValidator;

    public AuthenticationApplication(IUnitOfWork unitOfWork, IMapper mapper, UsersDtoValidator usersDtoValidator)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _usersDtoValidator = usersDtoValidator;
    }

    public Response<UserDTO> Authenticate(string username, string password)
    {
      var response = new Response<UserDTO>();
      var validation = _usersDtoValidator.Validate(new UserDTO() { UserName = username, Password = password });

      if (!validation.IsValid)
      {
        response.Message = "Errores de Validación";
        response.Errors = validation.Errors;
        return response;
      }
      try
      {
        var user = _unitOfWork.AuthenticationRepository.Authenticate(username, password);
        response.Data = _mapper.Map<UserDTO>(user);
        response.IsSuccess = true;
        response.Message = "Autenticación Exitosa!!!";
      }
      catch (InvalidOperationException)
      {
        response.IsSuccess = true;
        response.Message = "Usuario no existe";
      }
      catch (Exception e)
      {
        response.Message = e.Message;
      }
      return response;
    }


  }
}
