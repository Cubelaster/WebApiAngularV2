using BL.Helpers;
using BL.ViewModels.Account;
using FluentValidation;

namespace BL.Validations.ViewModels
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(vm => vm.UserName).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(vm => vm.Email).NotEmpty().Must(RegexHelpers.IsValidEmail).WithMessage("Email cannot be empty");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(vm => vm.PasswordConfirmed).Equal(vm => vm.Password).WithMessage("Both passwords must match");
        }
    }
}