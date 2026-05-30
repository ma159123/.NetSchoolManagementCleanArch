using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Abstractions.infra_abstract;
using SchoolManagement.Core.Entities.identity;
using SchoolManagement.Infrastructure.Bases;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.impl
{
    public class AuthRepo : GenericRepo<UserRefreshToken>, IAuthRepo
    {
        private readonly DbSet<UserRefreshToken> userRefreshTokens;
        public AuthRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            userRefreshTokens = dbContext.userRefreshTokens;
        }

        public async Task<UserRefreshToken?> GetUserRefreshToken(string refreshToken, string userId)
        {
            return await userRefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken && x.UserId == userId);
        }
    }
}
