using System;
using System.Collections.Generic;
using LibraryAPI.Interfaces;

namespace LibraryAPI.Models
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public virtual ICollection<RequestModel> Requests { get; set; }
        public User()
        {
        }

        public User(Guid id, string username, string role, string password)
        {
            Id = id;
            Username = username;
            Role = role;
            Password = password;
        }
    }
}