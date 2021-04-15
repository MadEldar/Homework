using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(LibraryContext context) : base(context) { }
    }
}