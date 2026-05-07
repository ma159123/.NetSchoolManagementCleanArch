using MediatR;
using SchoolManagement.Core.Features.Students.Queries.Results;
using SchoolManagement.Core.Wrapper;
using SchoolManagement.Data.Data;

namespace SchoolManagement.Core.Features.Students.Queries.Models
{
    public class GetPaginatedStudentListQuery : IRequest<PaginatedList<GetPaginatedStudentList>>
    {
        public int Page { get; set; } = 1;
        public int ItemsCount { get; set; } = 10;
        public string? Search { get; set; }
        public FilterStudentsEnum? OrderBy { get; set; }
        public GetPaginatedStudentListQuery(int Page, int ItemsCount, string? search, FilterStudentsEnum? orderBy)
        {
            this.Page = Page;
            this.ItemsCount = ItemsCount;
            Search = search;
            OrderBy = orderBy;
        }
        public GetPaginatedStudentListQuery()
        {

        }
    }
}
