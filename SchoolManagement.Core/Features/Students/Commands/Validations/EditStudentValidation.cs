using FluentValidation;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Service.Abstract;

namespace SchoolManagement.Core.Features.Students.Commands.Validations
{
    public class EditStudentValidation : AbstractValidator<EditStudentCommand>
    {
        public IStudentService studentService { get; }

        public EditStudentValidation(IStudentService studentService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            this.studentService = studentService;
        }

        public void ApplyValidationRules()
        {
            RuleFor(s => s.StudID).NotNull().WithMessage("Id must be not empty!");
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(s => s.Phone).MustAsync(async (model, key, cancellationToken) => !await studentService.isPhoneExist(model.StudID, key)).WithMessage("phone already linked to another student");
        }
    }
}
