using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Enums;
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

        public async Task<int> GetCountAsync()
        {
            return await _repo
                .GetAll()
                .CountAsync()
                .ConfigureAwait(false);
        }

        public IQueryable<User> GetPaginatedList(int page, int limit)
        {
            return _repo
                .GetAll(/* u => u.Role != UserRole.Admin */)
                .OrderBy(u => u.Username)
                .Skip((page - 1) * limit)
                .Take(limit);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            if (id == default) throw new KeyNotFoundException();

            return await _repo
                .GetAll()
                .SingleOrDefaultAsync(u => u.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<OperatingStatus> CreateAsync(User user)
        {
            if (user == null) return OperatingStatus.InvalidArgument;
            else if (user.CheckEmptyFields()) return OperatingStatus.EmptyArgument;

            return await _repo.CreateAsync(user).ConfigureAwait(false);
        }

        public async Task<OperatingStatus> EditAsync(Guid id, User editedUser)
        {
            if (editedUser.CheckEmptyFields()) return OperatingStatus.EmptyArgument;

            editedUser.Id = id;

            return await _repo.EditAsync(editedUser).ConfigureAwait(false);
        }

        public async Task<OperatingStatus> DeleteAsync(Guid id)
        {
            var user = await GetByIdAsync(id).ConfigureAwait(false);

            if (user == null) return OperatingStatus.KeyNotFound;

            return await _repo.DeleteUserAsync(user).ConfigureAwait(false);
        }
    }
}