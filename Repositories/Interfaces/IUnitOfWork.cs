using Bookbox.Repositories.Interface;
using Bookbox.Repositories.Interfaces;

namespace Bookbox.Repositories.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepository<T> Repository { get; }
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        Task<bool> CompleteAsync();

    }
    
}