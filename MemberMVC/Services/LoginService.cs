using Homework_2021_03_25.Models;
using System.Linq;

namespace MemberMVC.Services
{
    public class LoginService
    {
        public User Authenticate(MemberMVCContext context, string username, string password)
        {
            return context.Users.FirstOrDefault(u => u.Username.ToLower().Equals(username.ToLower()) && u.Password.Equals(password));
        }
    }
}