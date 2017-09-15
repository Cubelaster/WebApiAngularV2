using BL.Validations.ViewModels;
using FluentValidation.Attributes;

namespace BL.ViewModels.Account
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
