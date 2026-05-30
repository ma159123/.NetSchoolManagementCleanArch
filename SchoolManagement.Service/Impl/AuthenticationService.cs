using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Core.Abstractions.infra_abstract;
using SchoolManagement.Core.Abstractions.service_abstract;
using SchoolManagement.Core.Data;
using SchoolManagement.Core.Entities.identity;
using SchoolManagement.Core.Features.Authentication.Commands.Results;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace SchoolManagement.Service.Impl
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthRepo _authRepo;
        private readonly UserManager<User> _userManager;
        public AuthenticationService(IAuthRepo authRepo, UserManager<User> userManager)
        {
            this._authRepo = authRepo;
            this._userManager = userManager;
        }
        public async Task<JwtAuthResult> GenerateUserToken(User user, IConfiguration configuration)
        {
            //make claims
            List<Claim> claims = new List<Claim>();
            //claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            //claims.Add(new Claim(nameof(UserClaim.UserName), user.UserName));
            //claims.Add(new Claim(nameof(UserClaim.Address), user.Address));
            //claims.Add(new Claim(nameof(UserClaim.Phone), user.PhoneNumber));
            //claims.Add(new Claim(nameof(UserClaim.Email), user.Email));

            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.StreetAddress, user.Address));
            claims.Add(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            var roles = await _userManager.GetRolesAsync(user);
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
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
                   expires: DateTime.UtcNow.AddHours(2),
                    signingCredentials: signingCredenials
                );

            //generate access token 
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenDesign);
            // 2.generate Refresh Token

            var refreshToken = _GenerateRefreshToken(tokenDesign.Id, user.Id);

            // 3. save Refresh Token in db
            await _authRepo.AddAsync(refreshToken);
            await _authRepo.SaveChangesAsync();
            return new JwtAuthResult
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };
        }

        public async Task<JwtAuthResult> RefreshToken(string accessToken, string refreshToken, IConfiguration configuration)
        {
            var (principal, validatedToken) = _ReadAccessToken(accessToken, configuration);
            if (validatedToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid Access Token");
            }

            // 2. جلب الـ Jti والـ UserId من الـ Access Token
            var jti = principal.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // 3. البحث عن الـ Refresh Token في قاعدة البيانات والتحقق من شروطه
            var storedRefreshToken = await _authRepo.GetUserRefreshToken(refreshToken, userId);

            if (storedRefreshToken == null ||
                storedRefreshToken.JwtId != jti ||
                storedRefreshToken.IsUsed ||
                storedRefreshToken.IsRevoked ||
                storedRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                throw new SecurityTokenException("Invalid or Expired Refresh Token");
            }

            // 4. استهلاك الـ Refresh Token القديم (ممارسة أمنية فضلى لعدم إعادة استخدامه)
            storedRefreshToken.IsUsed = true;
            await _authRepo.UpdateAsync(storedRefreshToken);

            // 5. generate new access and refresh tokens
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new SecurityTokenException("User not found");
            }
            return await GenerateUserToken(user, configuration);
        }

        UserRefreshToken _GenerateRefreshToken(string accessTokenId, string userId)
        {
            var refreshToken = new UserRefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                JwtId = accessTokenId,
                UserId = userId,
                IsUsed = false,
                IsRevoked = false,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(7)
            };
            return refreshToken;
        }

        (ClaimsPrincipal?, SecurityToken) _ReadAccessToken(string accessToken, IConfiguration configuration)
        {

            var jwtSettings = configuration.GetSection("Jwt").Get<JWTSettings>();
            var tokenHandler = new JwtSecurityTokenHandler();

            // إعدادات قراءة الـ Access Token المنتهي الصلاحية بدون رمي Exception
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtSettings.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                ValidateLifetime = false // 👈 هامة جداً: لأننا نريد قراءة التوكن حتى لو انتهت صلاحيته!
            };

            // 1. decode and read the invalid Access Token 
            var principal = tokenHandler.ValidateToken(accessToken, validationParameters, out SecurityToken validatedToken);
            return (principal, validatedToken);
        }
    }
}

