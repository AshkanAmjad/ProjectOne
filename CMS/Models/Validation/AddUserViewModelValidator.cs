﻿using CMS.Models.ViewModels.User;
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
            RuleFor( u => u.UserName).NotEmpty().WithMessage("User Name is Required.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is Required.");
            RuleFor(u => u.ConfirmPassword).Equal(p=>p.Password).WithMessage("Password does not match.");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Email is Invalid.");
        }
    }
}