using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Abstractions.service_abstract;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Entities.identity;
using SchoolManagement.Core.Features.Authentication.Commands.Models;
using SchoolManagement.Core.SharedResources;

namespace SchoolManagement.Core.Features.Authentication.Commands.Handlers
{
    public class UserAuthenticatiionHandlers : ResponseHandler, IRequestHandler<UserAuthenticationCommand, Response<string>>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;
        public readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourcesClass> _stringLocalizer;
        public UserAuthenticatiionHandlers(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration, IAuthenticationService authenticationService, IMapper mapper, IStringLocalizer<SharedResourcesClass> stringLocalizer) : base(stringLocalizer)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authenticationService = authenticationService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _configuration = configuration;
        }
        public async Task<Response<string>> Handle(UserAuthenticationCommand request, CancellationToken cancellationToken)
        {
            //check if user exist
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return BadRequest<string>("User not found!");
            }

            //check password
            var isCorrectPass = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isCorrectPass)
            {
                return BadRequest<string>("Incorect UserName or Password");
            }
            //make token
            var token = _authenticationService.GenerateUserToken(user, _configuration);
            //try to sign in
            return Success(token);
        }
    }
}
