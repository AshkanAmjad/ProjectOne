using CMS.Models.ViewModel;
using FluentValidation;

namespace CMS.Models.Validation
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Please Enter Your User Name");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please Enter Your Password");
         }
    }
}