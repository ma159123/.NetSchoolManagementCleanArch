namespace SchoolManagement.Core.Features.Authentication.Commands.Results
{

    public class JwtAuthResult
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
