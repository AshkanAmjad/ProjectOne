using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModels.Models.Article;

namespace CMS.Models.Validation
{
    public class AddArticleViewModelValidatior : AbstractValidator<AddAritcleViewModel>
    {
        public AddArticleViewModelValidatior()
        {
            RuleFor(a => a.Title).NotNull().WithMessage("Title is Required");
            RuleFor(a => a.Content).NotNull().WithMessage("Content is Required");
            RuleFor(a => a.PublishDate).NotNull().WithMessage("Publish Date is Required");
            RuleFor(a => a.CategoryId).NotEmpty().WithMessage("Category is Required");
        }
    }
}