using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly LibraryContext _context;
        private readonly DbSet<T> _dbSet;
        protected BaseRepository(LibraryContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            if (entity == null) {
                throw new MissingFieldException();
            }

            int currentCount = _dbSet.Count();

            await _dbSet.AddAsync(entity).ConfigureAwait(false);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return CountChanged(currentCount);
        }

        public async Task<bool> EditAsync(T editedEntity)
        {
            _context.Entry(editedEntity).State = EntityState.Modified;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            int currentCount = await _dbSet.CountAsync().ConfigureAwait(false);

            _dbSet.Remove(entity);

            _context.SaveChanges();

            return CountChanged(currentCount);
        }

        private bool CountChanged(int currentCount)
        {
            return _context.Books.Count() != currentCount;
        }
    }
}