using System;
using System.Linq;
using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public class HomeService
    {
        private readonly LibraryContext _context;
        public HomeService(LibraryContext context)
        {
            _context = context;
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password)) return null;

            var user = GetUserByUsernameAndPassword(username, password);

            if (user != null)
            {
                if (user.Token == null)
                {
                    _context.Tokens.Add(new UserToken(user.Id));
                    _context.SaveChanges();
                }
                else
                {
                    user.Token.RefreshToken();
                }
            }

            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}