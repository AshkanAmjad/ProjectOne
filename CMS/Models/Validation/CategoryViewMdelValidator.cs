using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModels.Models.Category;

namespace CMS.Models.Validation
{
    public class CategoryViewMdelValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryViewMdelValidator()
        {
            RuleFor(a => a.Title).NotNull()
                                 .WithMessage("Title is Required");
        }
    }
}