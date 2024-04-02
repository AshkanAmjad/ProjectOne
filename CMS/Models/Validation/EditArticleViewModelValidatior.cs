using FluentValidation;
using ViewModels.Models.Article;

namespace CMS.Models.Validation
{
    public class EditArticleViewModelValidatior : AbstractValidator<EditArticleViewModel>
    {
        public EditArticleViewModelValidatior()
        {
            RuleFor(a => a.Title).NotNull()
                                 .WithMessage("Title is Required");
         
            RuleFor(a => a.Content).NotNull()
                                   .WithMessage("Content is Required");

            RuleFor(a => a.Description).NotNull()
                                   .WithMessage("Description is Required");

            RuleFor(a => a.PublishDate).NotNull()
                                       .WithMessage("Publish Date is Required");
        }
    }
}