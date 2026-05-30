using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Abstractions.service_abstract;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authorization.Commands.Models;
using SchoolManagement.Core.SharedResources;

namespace SchoolManagement.Core.Features.Authentication.Commands.Handlers
{
    public class AuthorizationHandlers : ResponseHandler, IRequestHandler<AddRoleCommand, Response<string>>,
                                                          IRequestHandler<EditRoleCommand, Response<string>>,
                                                          IRequestHandler<DeleteRoleCommand, Response<string>>

    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IConfiguration _configuration;
        public readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourcesClass> _stringLocalizer;
        public AuthorizationHandlers(IConfiguration configuration, IAuthorizationService authorizationService, IMapper mapper, IStringLocalizer<SharedResourcesClass> stringLocalizer) : base(stringLocalizer)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _configuration = configuration;
        }
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            //check if user exist
            var result = await _authorizationService.AddRoleAsync(request.RoleName);
            if (result.Errors.Count() != 0)
            {
                string errorResult = "";
                foreach (var error in result.Errors)
                {
                    errorResult += error.Description;
                }
                return BadRequest<string>($"Error: {errorResult}");
            }

            return Created<string>("Added successfully");
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {

            //Edit role
            var res = await _authorizationService.EditRoleAsync(request.RoleName, request.RoleId);
            string errorResult = "";
            if (res.Errors.Count() != 0)
            {
                foreach (var error in res.Errors)
                {
                    errorResult += $", {error.Description}";
                }
                return BadRequest<string>(errorResult);
            }
            return Success<string>("Role Updated Successfully");
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var res = await _authorizationService.DeleteRoleByIdAsync(request.Id);
            if (res.Errors.Count() != 0)
            {
                string errorRes = string.Empty;
                foreach (var error in res.Errors)
                {
                    errorRes += $"{error.Description}, ";
                }
                return BadRequest<string>(errorRes);
            }
            return Success<string>("Deleted Successfully!");
        }
    }
}
