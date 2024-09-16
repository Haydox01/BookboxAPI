using Bookbox.Data;
using Bookbox.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public async Task AddRange(IList<T> entity)
        {
            await dbSet.AddRangeAsync(entity);
        }

        public virtual async Task<List<T>> All()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<T> ReadSingle(Guid EntityId)
        {
            return await dbSet.FindAsync(EntityId);
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
        /*public async Task Delete(Guid EntityId)
        {
            var entity = await ReadSingle(EntityId);
            table.Remove(entity);
        }
*/
        public void DeleteRange(IList<T> entity)
        {
             dbSet.RemoveRange(entity);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            return entity;

            
        }

        public void UpdateRange(IList<T> entities)
        {
            dbSet.UpdateRange(entities);
        }
    }
}
