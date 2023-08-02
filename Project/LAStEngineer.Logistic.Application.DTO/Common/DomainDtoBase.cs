namespace LAStEngineer.Logistic.Application.DTO.Common
{
  public abstract class DomainDtoBase
  {
    public string? KeyId { get; set; }
    public string? StateId { get; set; }
    public bool IsSystem { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }
  }
}
