using CMS.Models.Validation;
using CMS.Models.ViewModel;
using Domain.Entities.Security.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using ViewModels.Models.Article;
using ViewModels.Models.Category;
using ViewModels.Models.Comment;

namespace CMS.Models
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        static ValidatorFactory()
        {
            validators.Add(typeof(IValidator<LoginViewModel>), new LoginViewModelValidator());
            validators.Add(typeof(IValidator<Role>), new RoleViewModelValidator());
            validators.Add(typeof(IValidator<ViewModels.User.AddUserViewModel>), new AddUserViewModelValidator());
            validators.Add(typeof(IValidator<ViewModels.User.EditViewModel>), new EditUserViewModelValidator());
            validators.Add(typeof(IValidator<AddAritcleViewModel>), new AddArticleViewModelValidator()) ;
            validators.Add(typeof(IValidator<EditArticleViewModel>), new EditArticleViewModelValidatior());
            validators.Add(typeof(IValidator<CategoryViewModel>), new CategoryViewMdelValidator());
            validators.Add(typeof(IValidator<AddCommentViewModel>), new AddCommentViewModelValidator());
            validators.Add(typeof(IValidator<EditCommentViewModel>), new EditCommentViewModelValidator());

        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator;
            if (validators.TryGetValue(validatorType, out validator))
            {
                return validator;
            }
            return validator;
        }
    }
}