using Domain.Entities.Security.Model;
using FluentValidation;

namespace CMS.Models.Validation
{
    public class RoleViewModelValidator: AbstractValidator<Role>
    {
        public RoleViewModelValidator()
        {
            RuleFor(t => t.Title).NotEmpty()
                                 .WithMessage("Title is Required.");
        }
    }
}