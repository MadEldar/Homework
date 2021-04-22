using System;
using System.Collections.Generic;
using LibraryAPI.Enums;

namespace LibraryAPI.Models.Results
{
    public class RequestResult
    {
        public Guid Id { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UserId { get; set; }
        public UserResult User { get; set; }
        public List<BookResult> Books { get; set; }
    }
}