using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Abstractions.service_abstract;
using SchoolManagement.Core.Features.Authorization.Commands.Models;
using SchoolManagement.Core.SharedResources;

namespace SchoolManagement.Core.Features.Authorization.Commands.Validations
{
    public class AddRoleValidator : AbstractValidator<AddRoleCommand>
    {
        private readonly IStringLocalizer<SharedResourcesClass> _localizer;
        private IAuthorizationService _authorizationService;
        public AddRoleValidator(IStringLocalizer<SharedResourcesClass> localizer, IAuthorizationService authorizationService)
        {
            _localizer = localizer;
            _authorizationService = authorizationService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(r => r.RoleName).NotEmpty().WithMessage($"RoleName: {_localizer[SharedResourceKeys.Required]}").NotNull();
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(r => r.RoleName).MustAsync(async (r, c) => !await _authorizationService.isRoleExist(r));
        }
    }
}
