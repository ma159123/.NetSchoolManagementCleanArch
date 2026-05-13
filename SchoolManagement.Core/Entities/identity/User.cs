
using Microsoft.AspNetCore.Identity;

namespace SchoolManagement.Core.Entities.identity
{
    public class User : IdentityUser
    {
        public String? Address { get; set; }
    }
}
