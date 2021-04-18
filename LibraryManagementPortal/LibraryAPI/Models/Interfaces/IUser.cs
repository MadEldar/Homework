using System;
using LibraryAPI.Enums;

namespace LibraryAPI.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Username { get; set; }
        UserRole Role { get; set; }
        string Password { get; set; }
    }
}