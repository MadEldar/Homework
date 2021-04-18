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
        public CurrentUserRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<User> GetCurrentUserAsync(string username)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Username == username)
                .ConfigureAwait(false);
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