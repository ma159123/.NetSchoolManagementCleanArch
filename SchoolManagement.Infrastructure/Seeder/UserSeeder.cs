using Microsoft.AspNetCore.Identity;
using SchoolManagement.Core.Abstractions.Seeder;
using SchoolManagement.Core.Entities.identity;

namespace SchoolManagement.Infrastructure.Seeder
{
    public class UserSeeder : ISeeder
    {
        private readonly UserManager<User> _userManager;

        public UserSeeder(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            var defaultUsers = new[]
            {
            new { Email = "superadmin@school.com", Password = "Super@123", Role = "SuperAdmin", Name = "Super Admin" },
            new { Email = "admin@school.com", Password = "Admin@123", Role = "Admin", Name = "System Admin" },
            new { Email = "teacher@school.com", Password = "Teacher@123", Role = "Teacher", Name = "Default Teacher" }
        };

            foreach (var userData in defaultUsers)
            {
                if (await _userManager.FindByEmailAsync(userData.Email) == null)
                {
                    var user = new User
                    {
                        UserName = userData.Email.Split('@')[0],
                        Email = userData.Email,
                        FullName = userData.Name,
                        EmailConfirmed = true
                    };

                    var result = await _userManager.CreateAsync(user, userData.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, userData.Role);
                    }
                }
            }
        }
    }
}
