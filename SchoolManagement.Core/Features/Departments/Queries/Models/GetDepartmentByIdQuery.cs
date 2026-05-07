using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Departments.Queries.Results;

namespace SchoolManagement.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public GetDepartmentByIdQuery(int id, int pageNumber, int pageSize)
        {
            Id = id;
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
        }
    }
}
