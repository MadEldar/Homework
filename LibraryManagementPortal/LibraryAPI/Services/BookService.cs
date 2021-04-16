using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryAPI.Services
{
    public class BookService
    {
        private readonly BookRepository _repo;
        private readonly LibraryContext _context;
        public BookService(BookRepository repo, LibraryContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<List<Book>> GetPaginatedListAsync()
        {
            // return new IncludeService<Book, Category>(_context.Books, b => b.Category).includedEntity;
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.BookRequests).ThenInclude(r => r.Request)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            if (id == default) throw new KeyNotFoundException();

            // return new IncludeService<Book, Category>(_context.Books, b => b.Category).includedEntity
            //     .SingleOrDefault(b => b.Id == id);

            return await _context.Books
                .Include(b => b.Category).ThenInclude(c => c.Books)
                .Include(b => b.BookRequests).ThenInclude(r => r.Request)
                .SingleOrDefaultAsync(b => b.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<bool> CreateAsync(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            else if (book.CheckEmptyFields()) throw new MissingFieldException();

            return await _repo.CreateAsync(book).ConfigureAwait(false);
        }

        public async Task<bool> EditAsync(Guid id, Book editedBook)
        {
            if (editedBook.CheckEmptyFields()) throw new MissingFieldException();

            editedBook.Id = id;

            return await _repo.EditAsync(editedBook).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var book = await GetByIdAsync(id).ConfigureAwait(false);

            if (book == null) throw new ArgumentNullException(nameof(id));

            return await _repo.DeleteAsync(book).ConfigureAwait(false);
        }
    }
}