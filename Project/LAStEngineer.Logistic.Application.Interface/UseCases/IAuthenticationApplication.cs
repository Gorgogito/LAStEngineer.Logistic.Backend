﻿using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Cross.Common;

namespace LAStEngineer.Logistic.Application.Interface.UseCases
{
  public interface IAuthenticationApplication
  {
    Response<UserDTO> Authenticate(string username, string password);

  }
}
