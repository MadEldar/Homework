using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }
    }
}