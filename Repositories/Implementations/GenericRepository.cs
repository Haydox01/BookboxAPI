using Bookbox.Data;
using Bookbox.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookbox.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BookBoxDbContext dbContext;
        protected DbSet<T> dbSet;

        public GenericRepository(BookBoxDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<List<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> DeleteAsync(Guid id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            dbSet.Remove(entity);
            return entity;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }
    }
}
