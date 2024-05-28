using Bookbox.Models;

namespace Bookbox.Repositories.Interface
{
    public interface IBookRepository
    {
        Task<Book> UpdateBook(Guid id, Book book);
        Task<IEnumerable<Book>> GetBooksByAuthorName(string name);
        Task<IEnumerable<Book>> GetBooksByTitle(string title);
    }
}
