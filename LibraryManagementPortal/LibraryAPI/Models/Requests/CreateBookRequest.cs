using System;
using System.Collections.Generic;

namespace LibraryAPI.Models.Requests
{
    public class CreateBookRequest
    {
        public string Username { get; set; }
        public List<Guid> BookIds { get; set; }
    }
}