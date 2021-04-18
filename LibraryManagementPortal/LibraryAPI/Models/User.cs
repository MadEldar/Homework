using System;
using System.Collections.Generic;
using LibraryAPI.Enums;
using LibraryAPI.Interfaces;

namespace LibraryAPI.Models
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; }
        public virtual ICollection<RequestModel> Requests { get; set; }
        public User()
        {
        }

        public User(Guid id, string username, UserRole role, string password)
        {
            Id = id;
            Username = username;
            Role = role;
            Password = password;
        }

        public bool CheckEmptyFields()
        {
            return
                string.IsNullOrWhiteSpace(Username)
                || string.IsNullOrWhiteSpace(Password);
        }
    }
}