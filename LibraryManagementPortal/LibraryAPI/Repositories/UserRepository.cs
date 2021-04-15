using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(LibraryContext context) : base(context) { }
    }
}