using System.Linq;
using LibraryAPI.Models;
using LibraryAPI.Models.Results;

namespace LibraryAPI.Services
{
    // Change Models into corresponding Results
    public class ResultService
    {
        public UserResult GetUserResult(User user, bool includeRequest = false)
        {
            return new UserResult
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                Requests = includeRequest ? user.Requests
                    .Select(r => GetRequestResult(r))
                    .ToList() : null
            };
        }

        public CategoryResult GetCategoryResult(Category category, bool includeBook = false)
        {
            return new CategoryResult
            {
                Id = category.Id,
                Name = category.Name,
                Books = includeBook ? category.Books
                    .Select(b => new BookResult { Id = b.Id, Title = b.Title, Author = b.Author })
                    .ToList() : null
            };
        }

        public BookResult GetBookResult(Book book, bool includeRequest = false)
        {
            return new BookResult
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Category = new CategoryResult { Id = book.Category.Id, Name = book.Category.Name },
                Requests = includeRequest ? book.BookRequests
                    .Select(br => GetRequestResult(br.Request))
                    .ToList() : null
            };
        }

        public RequestResult GetRequestResult(RequestModel request, bool includeBook = false)
        {
            return new RequestResult
            {
                Id = request.Id,
                Status = request.Status,
                RequestedDate = request.RequestedDate,
                UpdatedDate = request.UpdatedDate ?? default,
                Books = includeBook ? request.BookRequests
                    .Select(br => GetBookResult(br.Book))
                    .ToList() : null
            };
        }
    }
}