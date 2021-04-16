using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;

namespace LibraryAPI.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _repo;
        private readonly LibraryContext _context;
        public CategoryService(CategoryRepository repo, LibraryContext context)
        {
            _repo = repo;
            _context = context;
        }

        public List<Category> GetPaginatedList()
        {
            return new IncludeService<Category, ICollection<Book>>(_context.Categories, c => c.Books).includedEntity;
        }

        public Category GetById(Guid id)
        {
            if (id == default) throw new KeyNotFoundException();

            return new IncludeService<Category, ICollection<Book>>(_context.Categories, c => c.Books).includedEntity
                .SingleOrDefault(c => c.Id == id);
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
            var book = GetById(id);

            if (book == null) throw new ArgumentNullException(nameof(id));

            return await _repo.DeleteAsync(book).ConfigureAwait(false);
        }
    }
}