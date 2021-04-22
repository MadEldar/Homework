using System.Threading.Tasks;
using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(LibraryContext context) : base(context) { }

        public async Task<bool> DeleteBookAsync(Book book)
        {
            if (book.BookRequests.Count > 0) return false;
            return await DeleteAsync(book).ConfigureAwait(false);
        }
    }
}