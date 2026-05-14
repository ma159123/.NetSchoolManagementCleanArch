using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Core.Abstractions.service_abstract;
using SchoolManagement.Core.Data;
using SchoolManagement.Core.Entities.identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace SchoolManagement.Service.Impl
{
    public class AuthenticationService : IAuthenticationService
    {

        public string GenerateUserToken(User user, IConfiguration configuration)
        {
            //make claims
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(nameof(UserClaim.UserName), user.UserName));
            claims.Add(new Claim(nameof(UserClaim.Address), user.Address));
            claims.Add(new Claim(nameof(UserClaim.Phone), user.PhoneNumber));
            claims.Add(new Claim(nameof(UserClaim.Email), user.Email));
            //Jwt settings

            var jwtSettings = configuration.GetSection("Jwt").Get<JWTSettings>();

            //create signing key
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
            //signing credentials
            var signingCredenials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            //designing token
            var tokenDesign = new JwtSecurityToken(
                    issuer: jwtSettings.Issuer,
                    audience: jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: signingCredenials
                );

            //generate token string
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenDesign);
            return tokenString;
        }
    }
}

