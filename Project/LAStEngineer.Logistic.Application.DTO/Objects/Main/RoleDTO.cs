using LAStEngineer.Logistic.Application.DTO.Common;

namespace LAStEngineer.Logistic.Application.DTO.Objects.Main
{

  public class RoleDTO : DomainDtoBase
  {

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Observation { get; set; }
  }

}
