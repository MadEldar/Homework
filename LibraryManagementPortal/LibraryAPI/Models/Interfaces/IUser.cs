using System;

namespace LibraryAPI.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Username { get; set; }
        string Role { get; set; }
        string Password { get; set; }
    }
}