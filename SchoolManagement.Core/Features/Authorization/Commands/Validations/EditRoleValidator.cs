using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Authorization.Commands.Models;
using SchoolManagement.Core.SharedResources;

namespace SchoolManagement.Core.Features.Authorization.Commands.Validations
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        private readonly IStringLocalizer<SharedResourcesClass> _localizer;
        public EditRoleValidator(IStringLocalizer<SharedResourcesClass> localizer)
        {
            _localizer = localizer;
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(r => r.RoleId).NotEmpty().WithMessage($"RoleId: {_localizer[SharedResourceKeys.Required]}").NotNull();

            RuleFor(r => r.RoleName).NotEmpty().WithMessage($"RoleName: {_localizer[SharedResourceKeys.Required]}").NotNull();
        }

    }
}
