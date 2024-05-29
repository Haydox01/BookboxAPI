using Bookbox.Dto;
using Bookbox.DTOs;

namespace Bookbox.Service.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBookAsync(string title);
        Task<BookDto> GetBookByIdAsync(Guid id);
        Task<BookDto> AddBookAsync(AddBookDto addBookDto);
        Task<BookDto> UpdateBookAsync(Guid id, UpdateBookDto updateBookDto);
        Task<BookDto> DeleteBookAsync(Guid id);
        Task<BookDto> GetBookByAuthorNameAsync(string name);
    }
}
