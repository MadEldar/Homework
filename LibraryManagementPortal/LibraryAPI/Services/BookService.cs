using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Enums;

namespace LibraryAPI.Services
{
    public class BookService
    {
        private readonly BookRepository _repo;
        public BookService(BookRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> GetCount()
        {
            return await _repo.GetAll().CountAsync().ConfigureAwait(false);
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

        public async Task<List<Book>> GetManyByIdAsync(List<Guid> ids, int page, int limit)
        {
            foreach (var id in ids)
            {
                if (id == default) throw new KeyNotFoundException();
            }

            return await _repo
                .GetAll()
                .Where(b => ids.Contains(b.Id))
                .Skip((page - 1) * limit)
                .Take(limit)
                .OrderBy(b => b.Title)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<OperatingStatus> CreateAsync(Book book)
        {
            if (book == null) return OperatingStatus.InvalidArgument;
            else if (book.CheckEmptyFields()) return OperatingStatus.EmptyArgument;

            return await _repo.CreateAsync(book).ConfigureAwait(false);
        }

        public async Task<OperatingStatus> EditAsync(Guid id, Book editedBook)
        {
            if (editedBook.CheckEmptyFields()) return OperatingStatus.KeyNotFound;
            else if (editedBook.CheckEmptyFields()) return OperatingStatus.EmptyArgument;

            editedBook.Id = id;

            return await _repo.EditAsync(editedBook).ConfigureAwait(false);
        }

        public async Task<OperatingStatus> DeleteAsync(Guid id)
        {
            var book = await GetByIdAsync(id).ConfigureAwait(false);

            if (book == null) return OperatingStatus.KeyNotFound;

            return await _repo.DeleteBookAsync(book).ConfigureAwait(false);
        }
    }
}