using System.Linq;
using LibraryAPI.Models;
using LibraryAPI.Models.Results;

namespace LibraryAPI.Services
{
    // Change Models into corresponding Results
    public class ResultService
    {
        public UserResult GetUserResult(User user, bool includeRequests = false, bool includeBooks = false)
        {
            return new UserResult
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                Requests = includeRequests ? user.Requests
                    .Select(r => GetRequestResult(r, includeBooks))
                    .ToList() : null
            };
        }

        public CategoryResult GetCategoryResult(Category category, bool includeBooks = false, bool includeRequests = false)
        {
            return new CategoryResult
            {
                Id = category.Id,
                Name = category.Name,
                Books = includeBooks ? category.Books
                    .Select(b => GetBookResult(b, includeRequests))
                    .ToList() : null
            };
        }

        public BookResult GetBookResult(Book book, bool includeRequests = false)
        {
            return new BookResult
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                CategoryId = book.CategoryId,
                Category = new CategoryResult { Id = book.Category.Id, Name = book.Category.Name },
                Requests = includeRequests ? book.BookRequests
                    .Select(br => GetRequestResult(br.Request))
                    .ToList() : null
            };
        }

        public RequestResult GetRequestResult(RequestModel request, bool includeBooks = false)
        {
            return new RequestResult
            {
                Id = request.Id,
                Status = request.Status,
                RequestedDate = request.RequestedDate,
                UpdatedDate = request.UpdatedDate ?? default,
                UserId = request.UserId,
                User = GetUserResult(request.User),
                Books = includeBooks ? request.BookRequests
                    .Select(br => GetBookResult(br.Book))
                    .ToList() : null
            };
        }
    }
}