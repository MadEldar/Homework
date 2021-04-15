using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;

namespace LibraryAPI.Services
{
    public class BookService
    {
        private readonly BookRepository _repo;
        public BookService(BookRepository repo)
        {
            _repo = repo;
        }

        public async Task<Book> GetBookById(Guid id)
        {
            if (id == default) throw new KeyNotFoundException();

            return await _repo.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Book>> GetBookPaginatedList()
        {
            return await _repo.GetListAsync().ConfigureAwait(false);
        }

        public async Task<bool> CreateBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            else if (book.CheckEmptyFields()) throw new MissingFieldException();

            return await _repo.CreateAsync(book).ConfigureAwait(false);
        }

        public async Task<bool> EditBook(Guid id, Book editedBook)
        {
            if (editedBook.CheckEmptyFields()) throw new MissingFieldException();

            await GetBookById(id).ConfigureAwait(false);

            return await _repo.EditAsync(editedBook).ConfigureAwait(false);
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            var book = await GetBookById(id).ConfigureAwait(false);

            return await _repo.DeleteAsync(book).ConfigureAwait(false);
        }
    }
}