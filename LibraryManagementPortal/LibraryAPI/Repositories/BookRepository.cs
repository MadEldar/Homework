using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(LibraryContext context) : base(context) { }

        public async Task<OperatingStatus> DeleteBookAsync(Book book)
        {
            if (book.BookRequests.Count > 0) return OperatingStatus.RelationshipExists;
            
            return await DeleteAsync(book).ConfigureAwait(false);
        }
    }
}