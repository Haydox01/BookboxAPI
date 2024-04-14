using Bookbox.Models;

namespace Bookbox.Repositories.Interface
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid id);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Guid id, Book book);
        Task<Book> DeleteBook(Guid id);
        Task<List<Book>> GetBooksByAuthorName(string authorName);
        Task<List<Book>> GetBooksByTitle(string title);
    }
}
