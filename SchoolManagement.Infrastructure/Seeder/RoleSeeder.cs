using Microsoft.AspNetCore.Identity;
using SchoolManagement.Core.Abstractions.Seeder;

namespace SchoolManagement.Infrastructure.Seeder
{
    public class RoleSeeder : ISeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleSeeder(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            var defaultRoles = new[]
            {
            "SuperAdmin",
            "Admin",
            "Teacher",
            "Student",
          };

            foreach (var roleName in defaultRoles)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
