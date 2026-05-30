using Microsoft.AspNetCore.Identity;
using SchoolManagement.Core.Abstractions.service_abstract;
using SchoolManagement.Core.Entities.identity;

namespace SchoolManagement.Service.Impl
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public AuthorizationService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IdentityResult> AddRoleAsync(string roleName)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleName;
            var result = await _roleManager.CreateAsync(role);
            return result;
        }

        public async Task<IdentityResult?> DeleteRoleByIdAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return IdentityResult.Failed(new IdentityError { Description = "Role not found" });
            var roleUsers = await _userManager.GetUsersInRoleAsync(role.Name);
            if (roleUsers != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Role has users assigned to!" });
            }
            var res = await _roleManager.DeleteAsync(role);
            return res;
        }

        public async Task<IdentityResult> EditRoleAsync(string roleName, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return IdentityResult.Failed(new IdentityError { Description = "Role not found" });
            if (role.Name != roleName && await isRoleExist(roleName))
                return IdentityResult.Failed(new IdentityError { Description = "Role name already exists" });
            role.Name = roleName;
            role.NormalizedName = roleName.ToUpper();
            var res = await _roleManager.UpdateAsync(role);
            return res;

        }

        public async Task<IdentityRole?> GetRoleByIdAsync(string roleId)
        {
            return await _roleManager.FindByIdAsync(roleId);
        }

        public async Task<List<IdentityRole>> GetRolesAsync()
        {
            return _roleManager.Roles.ToList();
        }

        public async Task<bool> isRoleExist(string roleName)
        {
            var res = await _roleManager.FindByNameAsync(roleName);
            return res != null;
        }
    }
}
