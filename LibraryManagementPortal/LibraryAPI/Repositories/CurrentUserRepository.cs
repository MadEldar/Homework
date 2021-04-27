using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public class CurrentUserRepository
    {
        private readonly LibraryContext _context;
        public CurrentUserRepository(LibraryContext context)
        {
            _context = context;
        }

        public User GetCurrentUser(string token)
        {
            var user = _context.Users
                .Where(u => u.Token != null && u.Token.Token == token)
                .FirstOrDefault();

            _context.SaveChanges();

            return user;
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

        public void RemoveExpiredToken(UserToken token)
        {
            _context.Tokens.Remove(token);
            _context.SaveChanges();
        }
    }
}