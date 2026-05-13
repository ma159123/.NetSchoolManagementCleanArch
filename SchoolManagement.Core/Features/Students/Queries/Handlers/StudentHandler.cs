using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Features.Students.Queries.Models;
using SchoolManagement.Core.Features.Students.Queries.Results;
using SchoolManagement.Core.SharedResources;
using SchoolManagement.Core.Wrapper;
using SchoolManagement.Service.Abstract;
using System.Linq.Expressions;

namespace SchoolManagement.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler : ResponseHandler, IRequestHandler<GetStudentsListQuery, Response<List<GetStudentsListResponse>>>,
                                                  IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>,
                                                  IRequestHandler<GetPaginatedStudentListQuery, PaginatedList<GetPaginatedStudentList>>
    {
        public IStudentService studentService { get; }
        public IMapper mapper { get; }
        private readonly IStringLocalizer<SharedResourcesClass> _localizer;

        public StudentHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResourcesClass> localizer) : base(localizer)
        {
            this.studentService = studentService;
            this.mapper = mapper;
            this._localizer = localizer;
        }

        public async Task<Response<List<GetStudentsListResponse>>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            var students = await studentService.GetStudentsAsync();
            var StudentsMapper = mapper.Map<List<GetStudentsListResponse>>(students);

            return Success(StudentsMapper);
        }

        public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await studentService.GetStudentByIdAsync(id: request.Id);
            if (student == null) return NotFound<GetStudentResponse>(_localizer[SharedResourceKeys.NotFound]);
            var studentMap = mapper.Map<GetStudentResponse>(student);
            return Success(studentMap);
        }



        public async Task<PaginatedList<GetPaginatedStudentList>> Handle(GetPaginatedStudentListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetPaginatedStudentList>> expression = e => new GetPaginatedStudentList(e.StudID, e.Name, e.Address, e.Phone, e.Department.DName);
            var students = studentService.GetQuerybleFilterStudents(request.OrderBy, request.Search);
            var paginatedList = await students.Select(expression).ToPaginatedListAsync(request.Page, request.ItemsCount);

            return paginatedList;
        }
    }
}
