using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModels.Models.Comment;

namespace CMS.Models.Validation
{
    public class AddCommentViewModelValidator: AbstractValidator<AddCommentViewModel>
    {
        public AddCommentViewModelValidator()
        {
            RuleFor(c => c.Title).NotEmpty()
                               .WithMessage("Title is Required.")
                               .MaximumLength(20)
                               .WithMessage("The maximum length of the Title is 20 characters.");
            RuleFor(c=>c.Content).NotEmpty()
                                 .WithMessage("Content is Required.")
                                 .MaximumLength(300)
                                 .WithMessage("The maximum length of the content is 300 characters.");
        }
    }
}