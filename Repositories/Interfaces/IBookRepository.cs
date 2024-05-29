using Bookbox.Models;
using Bookbox.Repositories.Interfaces;

namespace Bookbox.Repositories.Interface
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> UpdateBook(Guid id, Book book);
        Task<IEnumerable<Book>> GetBooksByAuthorName(string name);
        Task<IEnumerable<Book>> GetBooksByTitle(string title);
    }
}
