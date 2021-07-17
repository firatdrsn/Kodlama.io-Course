using Entities.Concrete;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u=>u.UserName).NotEmpty();
            //RuleFor(u=>u.Password).NotEmpty();
            RuleFor(u=>u.FirstName).NotEmpty();
            RuleFor(u=>u.Email).NotEmpty();
            //RuleFor(u => u.Password).MinimumLength(6);
            RuleFor(u => u.UserName).MinimumLength(3);
            RuleFor(u=>u.Email).EmailAddress();
        }
    }
}
