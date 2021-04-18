using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public interface IBaseRepository<T>
        where T : class
    {
        IQueryable<T> GetAll();
        Task<bool> CreateAsync(T entity);
        Task<bool> EditAsync(T editedEntity);
        Task<bool> DeleteAsync(T entity);
    }
}