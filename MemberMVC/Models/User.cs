using System;
using System.ComponentModel.DataAnnotations;
using Homework_2021_03_25.Controllers;

namespace Homework_2021_03_25.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}