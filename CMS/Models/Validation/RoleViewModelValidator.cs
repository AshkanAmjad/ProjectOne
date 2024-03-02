using Domain.Entities.Security.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Models.Validation
{
    public class RoleViewModelValidator: AbstractValidator<Role>
    {
        public RoleViewModelValidator()
        {
            RuleFor(t => t.Title).NotEmpty().WithMessage("Title is Required.");
        }
    }
}