using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models.Results;

namespace LibraryAPI.Services
{
    public class BookService
    {
        private readonly BookRepository _repo;
        public BookService(BookRepository repo)
        {
            _repo = repo;
        }

        public IQueryable<Book> GetPaginatedList(int page, int limit)
        {
            return _repo.GetAll()
                .OrderBy(b => b.Author)
                .ThenBy(b => b.Title)
                .Skip((page - 1) * limit)
                .Take(limit);
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            if (id == default) throw new KeyNotFoundException();

            return await _repo
                .GetAll()
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