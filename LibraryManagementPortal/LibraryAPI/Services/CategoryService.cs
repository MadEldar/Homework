using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _repo;
        public CategoryService(CategoryRepository repo)
        {
            _repo = repo;
        }

        public IQueryable<Category> GetPaginatedList(int page, int limit)
        {
            return _repo
                .GetAll()
                .OrderBy(c => c.Name)
                .Skip((page - 1) * limit)
                .Take(limit);
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            if (id == default) throw new KeyNotFoundException();

            return await _repo
                .GetAll()
                .SingleOrDefaultAsync(c => c.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<bool> CreateAsync(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            else if (category.CheckEmptyFields()) throw new MissingFieldException();

            return await _repo.CreateAsync(category).ConfigureAwait(false);
        }

        public async Task<bool> EditAsync(Guid id, Category editedCategory)
        {
            if (editedCategory.CheckEmptyFields()) throw new MissingFieldException();

            editedCategory.Id = id;

            return await _repo.EditAsync(editedCategory).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var book = await GetByIdAsync(id).ConfigureAwait(false);

            if (book == null) throw new ArgumentNullException(nameof(id));

            return await _repo.DeleteAsync(book).ConfigureAwait(false);
        }
    }
}