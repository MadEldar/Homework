using System;
using LibraryAPI.Enums;

namespace LibraryAPI.Models.Results
{
    public class UserResult
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public RequestResult Requests { get; set; }
    }
}