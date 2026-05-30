using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authorization.Queries.Results;

namespace SchoolManagement.Core.Features.Authorization.Queries.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleItemQueryResponse>>
    {
        public string Id { get; set; }
        public GetRoleByIdQuery(string id)
        {
            this.Id = id;
        }
    }
}
