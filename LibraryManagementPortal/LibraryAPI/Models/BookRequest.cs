using System;
using LibraryAPI.Models.Interfaces;

namespace LibraryAPI.Models
{
    public class BookRequest :  IBookRequest
    {
        public Guid BookId { get; set; }
        public Guid RequestId { get; set; }
        public virtual Book Book { get; set; }
        public virtual RequestModel Request { get; set; }
    }
}
