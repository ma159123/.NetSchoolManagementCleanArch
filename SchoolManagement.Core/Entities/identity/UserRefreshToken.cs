using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Entities.identity
{
    public class UserRefreshToken
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; } // link refresh token with access token
        public bool IsUsed { get; set; } //prevent use token more that once
        public bool IsRevoked { get; set; } // revoke token 
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
