using System;
using System.Linq;
using System.Collections.Generic;
using LibraryAPI.Interfaces;
using LibraryAPI.Enums;

namespace LibraryAPI.Models
{
    public class RequestModel : IRequest
    {
        public Guid Id { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<BookRequest> BookRequests { get; set; }

        public RequestModel()
        {
        }

        public RequestModel(Guid userId, DateTime requestedDate, DateTime updatedDate)
        {
            UserId = userId;
            RequestedDate = requestedDate;
            UpdatedDate = updatedDate;
        }

        public IEnumerable<Book> GetBooks()
        {
            return BookRequests.Select(br => br.Book);
        }
    }
}