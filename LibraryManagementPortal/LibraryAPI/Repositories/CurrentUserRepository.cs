using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Models;
using LibraryAPI.Models.Results;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class CurrentUserRepository
    {
        public LibraryContext _context;
        public CurrentUserRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<User> GetCurrentUserAsync(string username)
        {
            return await _context.Users
                .Include(u => u.Requests).ThenInclude(r => r.BookRequests).ThenInclude(br => br.Book).ThenInclude(b => b.Category)
                .SingleOrDefaultAsync(u => u.Username == username)
                .ConfigureAwait(false);
        }

        public List<RequestResult> GetBooksFromRequests(ICollection<RequestModel> requests)
        {
            var result = new List<RequestResult>();

            foreach (var request in requests)
            {
                result.Add(
                    new RequestResult
                    {
                        Id = request.Id,
                        Status = request.Status,
                        RequestedDate = request.RequestedDate,
                        UpdatedDate = request.UpdatedDate ?? default,
                        Books = request.BookRequests
                            .Select(br => new BookResult
                            {
                                Id = br.Book.Id,
                                Title = br.Book.Title,
                                Author = br.Book.Author,
                                Category = new CategoryResult { Id = br.Book.Category.Id, Name = br.Book.Category.Name }
                            })
                            .ToList()
                    }
                );
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