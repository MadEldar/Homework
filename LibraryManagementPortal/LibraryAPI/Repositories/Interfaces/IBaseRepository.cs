using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetListAsync();
        Task<bool> CreateAsync(T entity);
        Task<bool> EditAsync(T editedEntity);
        Task<bool> DeleteAsync(T entity);
    }
}