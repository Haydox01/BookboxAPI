using Bookbox.Repositories.Interface;

namespace Bookbox.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IBookRepository Book { get; }
        IAuthorRepository Author { get; }
        Task CompleteAsync();

    }
    
}
