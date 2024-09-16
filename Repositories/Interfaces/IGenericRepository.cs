namespace Bookbox.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> All();
        Task<T> ReadSingle(Guid EntityId);
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task AddRange(IList<T> entity);
        Task<T> Update(T Entity);
        void UpdateRange(IList<T> entities);
        Task<T> DeleteAsync(Guid id);
        void DeleteRange(IList<T> entity);
    }
}
