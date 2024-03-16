using CMS.Models.ViewModels.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Models.Validation
{
    public class AddUserViewModelValidator : AbstractValidator<AddUserViewModel>
    {
        public AddUserViewModelValidator()
        {
            RuleFor( u => u.UserName).NotEmpty()
                                     .WithMessage("User Name is Required.")
                                     .MaximumLength(10)
                                     .WithMessage("The maximum length of the user name is 10 characters.");
          
            RuleFor(u => u.Password).NotEmpty()
                                    .WithMessage("Password is Required.")
                                    .MaximumLength(10)
                                    .WithMessage("The maximum length of the password is 10 characters."); 

            RuleFor(u => u.ConfirmPassword).Equal(p=>p.Password)
                                           .WithMessage("Password does not match.");
           
            RuleFor(u => u.Email).EmailAddress()
                                 .WithMessage("Email is Invalid.");
        }
    }
}