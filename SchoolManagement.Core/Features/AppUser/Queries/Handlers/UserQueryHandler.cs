using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Entities.identity;
using SchoolManagement.Core.Features.AppUser.Queries.Models;
using SchoolManagement.Core.Features.AppUser.Queries.Results;
using SchoolManagement.Core.SharedResources;
using SchoolManagement.Core.Wrapper;

namespace SchoolManagement.Core.Features.AppUser.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler, IRequestHandler<GetPaginatedUsersQuery, Response<PaginatedList<GetUserResponse>>>,
                                                     IRequestHandler<GetUserById, Response<GetUserResponse>>
    {
        private readonly UserManager<User> _userManager;
        public readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourcesClass> _stringLocalizer;
        public UserQueryHandler(UserManager<User> userManager, IMapper mapper, IStringLocalizer<SharedResourcesClass> stringLocalizer) : base(stringLocalizer)
        {
            _userManager = userManager;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<PaginatedList<GetUserResponse>>> Handle(GetPaginatedUsersQuery request, CancellationToken cancellationToken)
        {
            //get users
            var users = _userManager.Users;


            //mapping
            var mappedUser = await _mapper.ProjectTo<GetUserResponse>(users).ToPaginatedListAsync(request.PageIndex, request.PageSize);

            //return created
            return Success(mappedUser);
        }

        public async Task<Response<GetUserResponse>> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user is null)
                return NotFound<GetUserResponse>(_stringLocalizer[SharedResourceKeys.NotFound]);


            var mappedUser = _mapper.Map<GetUserResponse>(user);
            return Success(mappedUser);
        }
    }
}
