using System;
using System.Collections.Generic;
using LibraryAPI.Enums;

namespace LibraryAPI.Models.Results
{
    public class UserResult
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public List<RequestResult> Requests { get; set; }
    }
}