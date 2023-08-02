using AutoMapper;
using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Domain.Entities.Main;

namespace LAStEngineer.Logistic.Application.UseCases.Mappings
{

  public class MappingProfile : Profile
  {

    public MappingProfile()
    {
      CreateMap<Company, CompanyDTO>();
      CreateMap<Role, RoleDTO>();
    }

  }

}
