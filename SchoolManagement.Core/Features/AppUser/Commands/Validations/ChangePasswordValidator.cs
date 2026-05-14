using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.AppUser.Commands.Models;
using SchoolManagement.Core.SharedResources;

namespace SchoolManagement.Core.Features.AppUser.Commands.Validations
{
    internal class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        private readonly IStringLocalizer<SharedResourcesClass> _localizer;
        public ChangePasswordValidator(IStringLocalizer<SharedResourcesClass> localizer)
        {
            _localizer = localizer;
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(u => u.Id).NotEmpty().WithMessage($"Id: {_localizer[SharedResourceKeys.Required]}").NotNull();
            RuleFor(u => u.Password).NotEmpty().WithMessage($"Password: {_localizer[SharedResourceKeys.Required]}").NotNull();
            RuleFor(u => u.NewPassword).NotEmpty().WithMessage($"NewPassword: {_localizer[SharedResourceKeys.Required]}").NotNull();
            RuleFor(u => u.ConfirmedPassword).NotEmpty().WithMessage($"Password: {_localizer[SharedResourceKeys.Required]}").NotNull();
            RuleFor(u => u.ConfirmedPassword).Equal(u => u.NewPassword).WithMessage("Confirmed Password must be same Password").NotNull();

        }
    }
}
