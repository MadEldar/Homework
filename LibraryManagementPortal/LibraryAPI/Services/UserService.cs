using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;

namespace LibraryAPI.Services
{
    public class UserService
    {
        private readonly UserRepository _repo;
        private readonly LibraryContext _context;

        public UserService(UserRepository repo, LibraryContext context)
        {
            _repo = repo;
            _context = context;
        }

        public List<User> GetPaginatedList()
        {
            return new IncludeService<User, ICollection<RequestModel>>(_context.Users, u => u.Requests).includedEntity;
        }

        public User GetById(Guid id)
        {
            if (id == default) throw new KeyNotFoundException();

            return new IncludeService<User, ICollection<RequestModel>>(_context.Users, u => u.Requests).includedEntity
                .SingleOrDefault(u => u.Id == id);
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
            var book = GetById(id);

            if (book == null) throw new ArgumentNullException(nameof(id));

            return await _repo.DeleteAsync(book).ConfigureAwait(false);
        }
    }
}