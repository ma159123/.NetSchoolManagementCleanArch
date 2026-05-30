using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Abstractions.service_abstract;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authorization.Queries.Models;
using SchoolManagement.Core.Features.Authorization.Queries.Results;
using SchoolManagement.Core.SharedResources;

namespace SchoolManagement.Core.Features.Authorization.Queries.Handlers
{
    public class AuthorizationQueryHandlers : ResponseHandler, IRequestHandler<GetRolesListQuery, Response<List<GetRoleItemQueryResponse>>>,
                                                                IRequestHandler<GetRoleByIdQuery, Response<GetRoleItemQueryResponse>>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IConfiguration _configuration;
        public readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourcesClass> _stringLocalizer;
        public AuthorizationQueryHandlers(IConfiguration configuration, IAuthorizationService authorizationService, IMapper mapper, IStringLocalizer<SharedResourcesClass> stringLocalizer) : base(stringLocalizer)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _configuration = configuration;
        }
        public async Task<Response<List<GetRoleItemQueryResponse>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var res = await _authorizationService.GetRolesAsync();
            //mapping
            var mapRes = _mapper.Map<List<GetRoleItemQueryResponse>>(res);
            return Success(mapRes);
        }

        public async Task<Response<GetRoleItemQueryResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _authorizationService.GetRoleByIdAsync(request.Id);
            //mapping
            var mapRes = _mapper.Map<GetRoleItemQueryResponse>(res);
            return Success(mapRes);
        }
    }
}
