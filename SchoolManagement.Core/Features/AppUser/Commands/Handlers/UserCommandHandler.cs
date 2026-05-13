using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Entities.identity;
using SchoolManagement.Core.Features.AppUser.Commands.Models;
using SchoolManagement.Core.SharedResources;

namespace SchoolManagement.Core.Features.AppUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>,
                                                       IRequestHandler<UpdateUserCommand, Response<string>>
    {
        private readonly UserManager<User> _userManager;
        public readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourcesClass> _stringLocalizer;
        public UserCommandHandler(UserManager<User> userManager, IMapper mapper, IStringLocalizer<SharedResourcesClass> stringLocalizer) : base(stringLocalizer)
        {
            _userManager = userManager;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //check if exist
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                return BadRequest<string>("User Already Exist!");
            }

            //mapping
            var mappedUser = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(mappedUser);
            if (!result.Succeeded)
            {
                string errorResult = "Error: ";
                foreach (var error in result.Errors)
                {
                    errorResult += $"{error.Description}, ";
                }
                return BadRequest<string>(errorResult);
            }
            //return created
            return Created("User Created!");
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //check if exist
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {
                return NotFound<string>(_stringLocalizer[SharedResourceKeys.NotFound]);
            }

            //mapping
            _mapper.Map(request, user);

            // ⭐ Debug: Check after mapping
            Console.WriteLine($"After Map: FullName={user.FullName}, Address={user.Address}");

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                string errorResult = "Error: ";
                foreach (var error in result.Errors)
                {
                    errorResult += $"{error.Description}, ";
                }
                return BadRequest<string>(errorResult);
            }
            //return created
            return Created("User Updated!");
        }
    }
}
