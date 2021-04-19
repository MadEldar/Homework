using System.Net;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;

namespace LibraryAPI.Services
{
    public class CurrentUserService
    {
        private readonly CurrentUserRepository _repo;
        public CurrentUserService(CurrentUserRepository repo)
        {
            _repo = repo;
        }

        public User GetCurrentUser(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return null;

            return _repo.GetCurrentUser(token);
        }

        public async Task<HttpResponseMessage> CreateNewRequestAsync(string username, List<Guid> bookIds)
        {
            if (bookIds.Count != bookIds.Distinct().Count())
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "You cannot borrow the same book more than once in one request"
                };
            }

            User user = _repo.GetCurrentUser(username);

            if (user == null)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Cannot find user. Please login again"
                };
            }

            var currentMonthRequests = user.Requests.Where(r => r.RequestedDate.Month == DateTime.Now.Month);

            var allRequests = UnwrapBookRequests(currentMonthRequests.Select(r => r.BookRequests));

            if (currentMonthRequests.Count() == 3)
            {
                return new HttpResponseMessage
                {
                    StatusCode = (HttpStatusCode) 418,
                    ReasonPhrase = "You have already reached this month's request limit"
                };
            }
            else if (allRequests.Count > 5)
            {
                return new HttpResponseMessage
                {
                    StatusCode = (HttpStatusCode) 418,
                    ReasonPhrase = "You have already reached this month's book limit"
                };
            }
            else if (allRequests.Count + bookIds.Count > 5)
            {
                return new HttpResponseMessage
                {
                    StatusCode = (HttpStatusCode) 418,
                    ReasonPhrase = "Total books requested exceeds your remaining book limit"
                };
            }

            await _repo.CreateBookRequestAsync(user.Id, bookIds).ConfigureAwait(false);

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                ReasonPhrase = $"Successfully requested {bookIds.Count} books"
            };
        }

        public ICollection<RequestModel> GetAllRequests(string token)
        {
            User user = _repo.GetCurrentUser(token);

            if (user == null) return null;

            return user.Requests;
        }

        private static List<BookRequest> UnwrapBookRequests(IEnumerable<ICollection<BookRequest>> wrappedRequests)
        {
            var allRequests = new List<BookRequest>();

            foreach (var bookRequests in wrappedRequests)
            {
                foreach (var request in bookRequests)
                {
                    allRequests.Add(request);
                }
            }

            return allRequests;
        }
    }
}