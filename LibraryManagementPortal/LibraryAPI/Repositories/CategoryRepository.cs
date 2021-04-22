using System.Threading.Tasks;
using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(LibraryContext context) : base(context) { }

        public async Task<bool> DeleteCategoryAsync(Category category)
        {
            if (category.Books.Count > 0) return false;

            return await DeleteAsync(category).ConfigureAwait(false);
        }
    }
}