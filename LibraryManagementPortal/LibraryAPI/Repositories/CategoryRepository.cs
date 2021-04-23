using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(LibraryContext context) : base(context) { }

        public async Task<OperatingStatus> DeleteCategoryAsync(Category category)
        {
            if (category.Books.Count > 0) return OperatingStatus.RelationshipExists;

            return await DeleteAsync(category).ConfigureAwait(false);
        }
    }
}