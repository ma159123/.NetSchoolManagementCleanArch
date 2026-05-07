using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Core.SharedResources;
using SchoolManagement.Data.Entities;
using SchoolManagement.Service.Abstract;

namespace SchoolManagement.Core.Features.Students.Commands.Handlers
{
    internal class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>,
                                                            IRequestHandler<EditStudentCommand, Response<string>>,
                                                            IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        public IStudentService studentService { get; }
        private readonly IStringLocalizer<SharedResourcesClass> _localizer;
        public IMapper mapper { get; }
        public StudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResourcesClass> localizer) : base(localizer)
        {
            this.studentService = studentService;
            this.mapper = mapper;
            this._localizer = localizer;
        }


        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return BadRequest<string>(_localizer[SharedResourceKeys.FillAllFields]);
            }
            var student = mapper.Map<Student>(request);
            if (student == null)
            {
                return BadRequest<string>();
            }
            await studentService.AddStudent(student);
            return Success<string>("Added");
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return BadRequest<string>("UPdate at least one field");
            }
            var student = await studentService.GetStudentByIdWithNoTrackAsync(request.StudID);
            if (student == null)
            {
                return NotFound<string>();
            }
            var mappedStudent = mapper.Map(request, student);
            if (mappedStudent == null)
            {
                return NotFound<string>();
            }
            string res = await studentService.EditStudent(mappedStudent);
            return Success("Updated Successfully");

        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            // check if exist
            if (request == null) return BadRequest<string>("You Must Enter Id");
            var student = await studentService.GetStudentByIdAsync(request.Id);
            if (student == null) return NotFound<string>();
            //mapping if needed

            //use service
            await studentService.DeleteStudent(student);
            return Deleted<string>();
        }
    }
}
