using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Authentication.Commands.Models;
using SchoolManagement.Core.SharedResources;

namespace SchoolManagement.Core.Features.Authentication.Commands.Validations
{
    public class UserAuthenticationValidator : AbstractValidator<UserAuthenticationCommand>
    {
        private readonly IStringLocalizer<SharedResourcesClass> _localizer;
        public UserAuthenticationValidator(IStringLocalizer<SharedResourcesClass> localizer)
        {
            _localizer = localizer;
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage($"UserName: {_localizer[SharedResourceKeys.Required]}").NotNull();
            RuleFor(u => u.Password).NotEmpty().WithMessage($"Password: {_localizer[SharedResourceKeys.Required]}").NotNull();
        }
    }
}
