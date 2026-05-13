using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.AppUser.Queries.Results;
using SchoolManagement.Core.Wrapper;

namespace SchoolManagement.Core.Features.AppUser.Queries.Models
{
    public class GetPaginatedUsersQuery : IRequest<Response<PaginatedList<GetUserResponse>>>
    {

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

    }
}
