using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Abstractions.service_abstract;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Core.SharedResources;

namespace SchoolManagement.Core.Features.Students.Commands.Validations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStringLocalizer<SharedResourcesClass> _localizer;
        private readonly IDepartmentService _departmentService;
        public AddStudentValidator(IStringLocalizer<SharedResourcesClass> localizer, IDepartmentService departmentService)
        {
            _localizer = localizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();
            _departmentService = departmentService;
        }

        public void ApplyValidationRules()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage($"Name: {_localizer[SharedResourceKeys.Required]}").MaximumLength(20).NotNull();
            RuleFor(s => s.Phone).NotEmpty().WithMessage($"Phone: {_localizer[SharedResourceKeys.Required]}").MaximumLength(11).NotNull();
            RuleFor(s => s.DepartmentId).NotEmpty().WithMessage($"DepartmentId: {_localizer[SharedResourceKeys.Required]}").NotNull();

        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(s => s.DepartmentId).MustAsync(async (key, c) => await _departmentService.CheckDepartmentByIdAsync(key))
                .WithMessage(_localizer[SharedResourceKeys.NotFound]);
        }
    }
}
