using Bookbox.DTOs;
using Bookbox.DTOs.Request;
using Bookbox.DTOs.Response;
using System.Collections.Generic;

namespace Bookbox.Service.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBookAsync(string title);
        Task<BookDto> GetBookByIdAsync(Guid id);
        Task<BookDto> AddBookAsync(AddBookDto addBookDto);
        Task<BookDto> UpdateBookAsync(Guid id, UpdateBookDto updateBookDto);
        Task<BookDto> DeleteBookAsync(Guid id);
        Task<List<BookDto>> GetBookByAuthorNameAsync(string name);
    }
}
