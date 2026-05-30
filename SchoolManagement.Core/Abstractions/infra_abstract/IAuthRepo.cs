using SchoolManagement.Core.Entities.identity;

namespace SchoolManagement.Core.Abstractions.infra_abstract
{
    public interface IAuthRepo : IGenericRepo<UserRefreshToken>
    {
        public Task<UserRefreshToken?> GetUserRefreshToken(string refreshToken, string userId);
    }
}
