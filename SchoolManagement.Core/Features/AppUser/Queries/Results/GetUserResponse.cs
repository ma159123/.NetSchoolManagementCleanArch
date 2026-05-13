namespace SchoolManagement.Core.Features.AppUser.Queries.Results
{
    public class GetUserResponse
    {
        public string FullName { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public String? Address { get; set; }
        public string Email { get; set; }
    }
}
