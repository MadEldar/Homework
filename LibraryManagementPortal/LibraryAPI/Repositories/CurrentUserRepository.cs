using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Models;
using LibraryAPI.Models.Results;
using LibraryAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class CurrentUserRepository
    {
        private readonly LibraryContext _context;
        private readonly ResultService _resultService;
        public CurrentUserRepository(LibraryContext context, ResultService resultService)
        {
            _context = context;
            _resultService = resultService;
        }

        public async Task<User> GetCurrentUserAsync(string username)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Username == username)
                .ConfigureAwait(false);
        }

        public List<RequestResult> GetBooksFromRequests(ICollection<RequestModel> requests)
        {
            var result = new List<RequestResult>();

            foreach (var request in requests)
            {
                result.Add(_resultService.GetRequestResult(request));
            }

            return result;
        }

        public async Task CreateBookRequestAsync(Guid userId, List<Guid> bookIds)
        {
            var request = new RequestModel { Status = RequestStatus.Pending, UserId = userId };

            _context.Requests.Add(request);
            bookIds.ForEach(async id =>
                await _context
                    .BookRequests
                    .AddAsync(new BookRequest { BookId = id, RequestId = request.Id })
                    .ConfigureAwait(false)
            );

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}