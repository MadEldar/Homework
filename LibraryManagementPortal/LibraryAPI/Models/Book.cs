using LibraryAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Models
{
    public class Book : IBook
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<BookRequest> BookRequests { get; set; }
        public Book()
        {
        }
        public Book(Guid id, string title, string author, Guid categoryId)
        {
            Id = id;
            Title = title;
            Author = author;
            CategoryId = categoryId;
        }
        public bool CheckEmptyFields()
        {
            return
                Id == default
                || string.IsNullOrWhiteSpace(Title)
                || string.IsNullOrWhiteSpace(Author)
                || CategoryId == default;
        }
        public IEnumerable<RequestModel> GetRequests()
        {
            return BookRequests.Select(br => br.Request).ToList();
        }
    }
}