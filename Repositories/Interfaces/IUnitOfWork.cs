using Bookbox.Repositories.Interface;

namespace Bookbox.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        Task CompleteAsync();

    }
    
}
