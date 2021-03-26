using System;
using System.ComponentModel.DataAnnotations;
using Homework_2021_03_25.Controllers;

namespace Homework_2021_03_25.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public int RoleId { get; set; }

        internal static void Authenticate(string v)
        {
            throw new NotImplementedException();
        }

        public static User Authenticate(String username, String password)
        {
            return HomeController.userList.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password.Equals(password));
        }
        public Role GetRole() {
            return HomeController.roleList.Find(r => r.Id == RoleId);
        }
    }
}