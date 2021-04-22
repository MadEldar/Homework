using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly DbSet<User> _dbSet;
        public UserRepository(LibraryContext context) : base(context)
        {
            _dbSet = context.Users;
        }

        public IQueryable<User> GetAll(Expression<Func<User, bool>> func)
        {
            return _dbSet.Where(func);
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            if (user.Requests.Count > 0) return false;
            return await DeleteAsync(user).ConfigureAwait(false);
        }
    }
}