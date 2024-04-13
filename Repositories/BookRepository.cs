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
        public async Task<Book> CreateBook(Book book)
        {

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book;

        }

        public async Task<Book> DeleteBook(Guid id)
        {
            var Book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (Book == null)
            {
                return null;
            }
            context.Books.Remove(Book);
            await context.SaveChangesAsync();
            return Book;

        }

        public async Task<List<Book>> GetAllBooks()
        {
           return await context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(Guid id)
        {
          return await context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Book>> GetBooksByTitle(string title)
        {
             
             // Use LINQ to filter books by title (case-insensitive)
          var booksWithTitle = await context.Books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
          .ToListAsync();

           return booksWithTitle;

        }

        public async Task<List<Book>> GetBooksByAuthorName(string authorName)
        {
            var booksByAuthor = await context.Books.Where(b => b.AuthorName.Contains(authorName, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
            return booksByAuthor;
            
        }

        public async Task<Book> UpdateBook(Book book)
        {
          
          var Book= await context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
            if (Book == null)
            {
                return null;
            }
            Book.Title = book.Title;
            Book.Price = book.Price;
            Book.ISBN = book.ISBN;

            await context.SaveChangesAsync();
            return Book;


        }

       
    }
}

