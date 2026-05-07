using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Departments.Queries.Models;
using SchoolManagement.Core.Features.Departments.Queries.Results;
using SchoolManagement.Core.SharedResources;
using SchoolManagement.Core.Wrapper;
using SchoolManagement.Service.Abstract;

namespace SchoolManagement.Core.Features.Departments.Queries.Handler
{
    public class DepartmentQueryHandler : ResponseHandler, IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        private readonly IDepartmentService departmentService;
        private readonly IStudentService studentService;
        private readonly IStringLocalizer<SharedResourcesClass> _localizer;
        private readonly IMapper _mapper;
        public DepartmentQueryHandler(IDepartmentService departmentService, IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResourcesClass> localizer) : base(localizer)
        {
            this.departmentService = departmentService;
            this.studentService = studentService;
            this._localizer = localizer;
            this._mapper = mapper;
        }
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            //Get dept from service
            var department = await departmentService.GetDepartmentByIdAsync(request.Id);
            // check if exist
            if (department == null)
            {
                return NotFound<GetDepartmentByIdResponse>(_localizer[SharedResourceKeys.NotFound]);
            }
            //paginate
            var students = studentService.GetQuerybleStudents().Where(s => s.DID == department.DID);
            var paginatedStudents = await students.Select((s) => new DeptStudentResponse { Id = s.StudID, StudentName = s.Name }).ToPaginatedListAsync(request.pageNumber, request.pageSize);
            //mapping
            var departmentResponse = _mapper.Map<GetDepartmentByIdResponse>(department);
            departmentResponse.Students = paginatedStudents;
            //return result
            return Success(departmentResponse);
        }
    }
}
