using Microsoft.AspNetCore.Identity;

namespace SchoolManagement.Core.Abstractions.service_abstract
{
    public interface IAuthorizationService
    {
        public Task<List<IdentityRole>> GetRolesAsync();
        public Task<IdentityResult> AddRoleAsync(string roleName);

        public Task<IdentityResult> EditRoleAsync(string roleName, string roleId);
        public Task<bool> isRoleExist(string roleName);
        Task<IdentityRole?> GetRoleByIdAsync(string roleId);

        Task<IdentityResult?> DeleteRoleByIdAsync(string roleId);

    }
}
