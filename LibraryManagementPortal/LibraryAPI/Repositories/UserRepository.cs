using System;
using System.Linq;
using System.Linq.Expressions;
using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly LibraryContext _context;
        public UserRepository(LibraryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll(Expression<Func<User, bool>> func)
        {
            return _context.Users.Where(func);
        }
    }
}