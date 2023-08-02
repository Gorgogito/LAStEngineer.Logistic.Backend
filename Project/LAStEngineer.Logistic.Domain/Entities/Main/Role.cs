using LAStEngineer.Logistic.Domain.Common;

namespace LAStEngineer.Logistic.Domain.Entities.Main
{

  public class Role : DomainModelBase
  {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Observation { get; set; }
  }
}
