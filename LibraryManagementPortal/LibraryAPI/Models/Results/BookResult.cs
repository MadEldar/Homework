using System;

namespace LibraryAPI.Models.Results
{
    public class BookResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public CategoryResult Category { get; set; }
        public RequestResult Requests { get; set; }
    }
}