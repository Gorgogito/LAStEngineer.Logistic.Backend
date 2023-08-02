using LAStEngineer.Logistic.Domain.Common;

namespace LAStEngineer.Logistic.Domain.Entities.Main
{
  public class Company : DomainModelBase
  {
    public string? Ruc { get; set; }
    public string? Description { get; set; }
    public string? Observation { get; set; }
    public string? Address { get; set; }
    public string? Agent { get; set; }
    public string? Phone { get; set; }
    public string? EMail { get; set; }
    public string? Web { get; set; }
  }
}
