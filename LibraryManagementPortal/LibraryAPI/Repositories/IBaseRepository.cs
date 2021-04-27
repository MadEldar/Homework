using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Enums;

namespace LibraryAPI.Repositories
{
    public interface IBaseRepository<T>
        where T : class
    {
        IQueryable<T> GetAll();
        Task<OperatingStatus> CreateAsync(T entity);
        Task<OperatingStatus> EditAsync(T editedEntity);
        Task<OperatingStatus> DeleteAsync(T entity);
    }
}