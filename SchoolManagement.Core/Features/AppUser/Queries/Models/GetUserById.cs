using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.AppUser.Queries.Results;

namespace SchoolManagement.Core.Features.AppUser.Queries.Models
{
    public class GetUserById : IRequest<Response<GetUserResponse>>
    {
        public string Id { get; set; }
        public GetUserById(string id)
        {
            Id = id;
        }
    }
}
