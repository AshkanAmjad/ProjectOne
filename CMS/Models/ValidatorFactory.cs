using CMS.Models.Validation;
using CMS.Models.ViewModel;
using CMS.Models.ViewModels.User;
using Domain.Entities.Security.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
namespace CMS.Models
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        static ValidatorFactory()
        {
            validators.Add(typeof(IValidator<LoginViewModel>), new LoginViewModelValidator());
            validators.Add(typeof(IValidator<Role>), new RoleViewModelValidator());
            validators.Add(typeof(IValidator<AddViewModel>), new AddUserViewModelValidator());
            validators.Add(typeof(IValidator<EditViewModel>), new EditUserViewModelValidator());
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