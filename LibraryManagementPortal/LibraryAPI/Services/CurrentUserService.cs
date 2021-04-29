using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using LibraryAPI.Enums;
using LibraryAPI.Resources;

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

            var user =  _repo.GetCurrentUser(token);

            if (user != null)
            {
                if (user.Token.ExpirationDate.AddHours(2) < DateTime.Now)
                {
                    _repo.RemoveExpiredToken(user.Token);
                    return null;
                }
                user.Token.RefreshToken();
            }

            return user;
        }

        public async Task<OperatingStatus> CreateNewRequestAsync(string token, List<Guid> bookIds)
        {
            if (bookIds.Count != bookIds.Distinct().Count()) return OperatingStatus.DuplicatedArgument;

            User user = _repo.GetCurrentUser(token);

            if (user == null) return OperatingStatus.KeyNotFound;

            var currentMonthRequests = user.Requests.Where(r => r.RequestedDate.Month == DateTime.Now.Month && r.Status != RequestStatus.Rejected);

            var allRequests = currentMonthRequests.SelectMany(r => r.BookRequests);

            if (currentMonthRequests.Count() == IntegerResource.monthlyTotalRequests) return OperatingStatus.ExceedMonthlyRequestLimit;
            else if (allRequests.Count() > IntegerResource.monthlyTotalBooks) return OperatingStatus.ExceedMonthlyBookLimit;
            else if (allRequests.Count() + bookIds.Count > IntegerResource.monthlyTotalBooks) return OperatingStatus.ExceedRemainingMonthlyRequestLimit;

            await _repo.CreateBookRequestAsync(user.Id, bookIds).ConfigureAwait(false);

            return OperatingStatus.Created;
        }

        public ICollection<RequestModel> GetAllRequests(string token)
        {
            User user = _repo.GetCurrentUser(token);

            if (user == null) return null;

            return user.Requests;
        }
    }
}