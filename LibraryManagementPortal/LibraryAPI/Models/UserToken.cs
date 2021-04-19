using System;
using LibraryAPI.Helpers;

namespace LibraryAPI.Models
{
    public class UserToken
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddHours(3);
        public virtual User User { get; set; }

        public UserToken(Guid userId)
        {
            UserId = userId;
            Token = RandomGenerator.GenerateToken();
        }

        public void RefreshToken()
        {
            ExpirationDate = ExpirationDate.AddHours(3);
        }
    }
}