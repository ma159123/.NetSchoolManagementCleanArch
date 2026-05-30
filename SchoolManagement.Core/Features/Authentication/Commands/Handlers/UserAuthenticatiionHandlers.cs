using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Abstractions.service_abstract;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Entities.identity;
using SchoolManagement.Core.Features.Authentication.Commands.Models;
using SchoolManagement.Core.Features.Authentication.Commands.Results;
using SchoolManagement.Core.SharedResources;

namespace SchoolManagement.Core.Features.Authentication.Commands.Handlers
{
    public class UserAuthenticatiionHandlers : ResponseHandler, IRequestHandler<UserAuthCommand, Response<JwtAuthResult>>,
                                                                IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;
        public readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourcesClass> _stringLocalizer;
        public UserAuthenticatiionHandlers(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration, IAuthenticationService authenticationService, IMapper mapper, IStringLocalizer<SharedResourcesClass> stringLocalizer) : base(stringLocalizer)
        {
            _userManager = userManager;
            _authenticationService = authenticationService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _configuration = configuration;
        }
        public async Task<Response<JwtAuthResult>> Handle(UserAuthCommand request, CancellationToken cancellationToken)
        {
            //check if user exist
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return BadRequest<JwtAuthResult>("User not found!");
            }

            //check password
            var isCorrectPass = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isCorrectPass)
            {
                return BadRequest<JwtAuthResult>("Incorect UserName or Password");
            }
            //make token
            var authResult = await _authenticationService.GenerateUserToken(user, _configuration);

            //try to sign in
            return Success(authResult);
        }

        public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {

            var result = await _authenticationService.RefreshToken(request.AccessToken, request.RefreshToken, _configuration);
            return Success(result);

        }
    }
}
