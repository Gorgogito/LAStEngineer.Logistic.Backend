using FluentValidation.Results;

namespace LAStEngineer.Logistic.Cross.Common
{
  public class ResponseGeneric<T>
  {
    public T Data { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public IEnumerable<ValidationFailure> Errors { get; set; }
  }
}
