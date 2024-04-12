using Bookbox.Data;
using Bookbox.MapperConfig;
using Bookbox.Models;
using Bookbox.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Bookbox.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookBoxDbContext context;
        private readonly MappingProfiles mappings;

        public BookRepository(BookBoxDbContext context, MappingProfiles mappings) {
            this.context = context;
            this.mappings = mappings;
        }
        public Task<Book> CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<Book> DeleteBook(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetAllBooks()
        {
           return await context.Books.ToListAsync();
        }

        public Task<Book> GetBookById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
