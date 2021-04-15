using System;

namespace LibraryAPI.Interfaces
{
    public interface IBook
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        Guid CategoryId { get; set; }
    }
}