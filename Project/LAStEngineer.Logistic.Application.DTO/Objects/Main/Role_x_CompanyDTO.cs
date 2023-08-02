using LAStEngineer.Logistic.Application.DTO.Common;

namespace LAStEngineer.Logistic.Application.DTO.Objects.Main
{
  public class Role_x_CompanyDTO : DomainDtoBase
  {
    private new string? KeyId { get; set; }
    public string? RoleId { get; set; }
    public string? CompanyId { get; set; }
  }
}
