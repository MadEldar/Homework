using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class UserService
    {
        private readonly UserRepository _repo;

        public UserService(UserRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<User>> GetPaginatedListAsync(int page, int limit)
        {
            return await _repo
                .GetAll(u => u.Role != "admin")
                .OrderBy(u => u.Username)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            if (id == default) throw new KeyNotFoundException();

            return await _repo
                .GetAll()
                .SingleOrDefaultAsync(u => u.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<bool> CreateAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            else if (user.CheckEmptyFields()) throw new MissingFieldException();

            return await _repo.CreateAsync(user).ConfigureAwait(false);
        }

        public async Task<bool> EditAsync(Guid id, User editedUser)
        {
            if (editedUser.CheckEmptyFields()) throw new MissingFieldException();

            editedUser.Id = id;

            return await _repo.EditAsync(editedUser).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var book = await GetByIdAsync(id).ConfigureAwait(false);

            if (book == null) throw new ArgumentNullException(nameof(id));

            return await _repo.DeleteAsync(book).ConfigureAwait(false);
        }
    }
}