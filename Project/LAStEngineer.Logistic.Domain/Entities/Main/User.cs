﻿using LAStEngineer.Logistic.Domain.Common;

namespace LAStEngineer.Logistic.Domain.Entities.Main
{

  public class User : DomainModelBase
  {
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Description { get; set; }
    public string? Observation { get; set; }
    public string? Names { get; set; }
    public string? Surnames { get; set; }
    public string? Phone { get; set; }
    public string? EMail { get; set; }
    public byte[]? Image { get; set; }
    public string? Token { get; set; }
    public string? RoleId { get; set; }
  }
}
