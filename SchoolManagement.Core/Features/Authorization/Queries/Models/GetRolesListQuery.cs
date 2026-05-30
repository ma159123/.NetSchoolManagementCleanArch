using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authorization.Queries.Results;

namespace SchoolManagement.Core.Features.Authorization.Queries.Models
{
    public class GetRolesListQuery : IRequest<Response<List<GetRoleItemQueryResponse>>>
    {

    }
}
