using System;
using System.Collections.Generic;

namespace LibraryAPI.Models.Results
{
    public class BookResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryResult Category { get; set; }
        public List<RequestResult> Requests { get; set; }
    }
}