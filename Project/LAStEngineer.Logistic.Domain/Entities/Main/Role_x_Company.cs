using LAStEngineer.Logistic.Domain.Common;

namespace LAStEngineer.Logistic.Domain.Entities.Main
{
  public class Role_x_Company : DomainModelBase
  {
    private new string? KeyId { get; set; }
    public string? RoleId { get; set; }
    public string? CompanyId { get; set; }
  }
}
