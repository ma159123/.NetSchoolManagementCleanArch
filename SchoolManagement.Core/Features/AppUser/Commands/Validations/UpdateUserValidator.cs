using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.AppUser.Commands.Models;
using SchoolManagement.Core.SharedResources;

namespace SchoolManagement.Core.Features.AppUser.Commands.Validations
{
    internal class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IStringLocalizer<SharedResourcesClass> _localizer;
        public UpdateUserValidator(IStringLocalizer<SharedResourcesClass> localizer)
        {
            _localizer = localizer;
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            //RuleFor(u => u.FullName).NotEmpty().WithMessage($"FullName: {_localizer[SharedResourceKeys.Required]}").MaximumLength(20).NotNull();
            //RuleFor(u => u.Email).NotEmpty().WithMessage($"Phone: {_localizer[SharedResourceKeys.Required]}").MaximumLength(11).NotNull();

        }
    }
}
