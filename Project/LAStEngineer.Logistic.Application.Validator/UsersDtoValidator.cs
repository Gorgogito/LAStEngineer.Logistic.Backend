using FluentValidation;
using LAStEngineer.Logistic.Application.DTO.Objects.Main;

namespace LAStEngineer.Logistic.Application.Validator
{
    public class UsersDtoValidator : AbstractValidator<UserDTO>
    {
        public UsersDtoValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}
