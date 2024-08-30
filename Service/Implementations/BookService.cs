using AutoMapper;
using Bookbox.Dto;
using Bookbox.Models;
using Bookbox.Repositories.Interfaces;
using Bookbox.Service.Interfaces;

namespace Bookbox.Service.Implementations
{

    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<BookDto>> GetAllBookAsync(string title)
        {
            if (string.IsNullOrEmpty(title) == false)
            {
                var bookName = await unitOfWork.Books.GetBooksByTitle(title);
                return mapper.Map<List<BookDto>>(bookName);
            }
            var books = await unitOfWork.Books.All();
            return mapper.Map<List<BookDto>>(books);
        }
        public async Task<List<BookDto>> GetBookByAuthorNameAsync(string authorName)
        {
            var books = await unitOfWork.Books.GetBooksByAuthorName(authorName);
            return mapper.Map<List<BookDto>>(books);
        }
        public async Task<BookDto> GetBookByIdAsync(Guid id)
        {
            var book = await unitOfWork.Books.GetByIdAsync(id);
            return mapper.Map<BookDto>(book);
        }
        public async Task<BookDto> AddBookAsync(AddBookDto addBookDto)
        {

            var book = mapper.Map<Book>(addBookDto);
            await unitOfWork.Books.AddAsync(book);
            await unitOfWork.CompleteAsync();
            return mapper.Map<BookDto>(book);
        }
        public async Task<BookDto> UpdateBookAsync(Guid id, UpdateBookDto updateBookDto)
        {
            var existingBook = mapper.Map<Book>(updateBookDto);
            await unitOfWork.Books.UpdateBook(id, existingBook);
            if (existingBook == null)
            {
                return null;
            }
            await unitOfWork.CompleteAsync();
            return mapper.Map<BookDto>(existingBook);
        }
        public async Task<BookDto> DeleteBookAsync(Guid id)
        {
            var existingBook = await unitOfWork.Books.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
            return mapper.Map<BookDto>(existingBook);
        }
    }
}

