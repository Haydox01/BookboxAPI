using Bookbox.Data;
using Bookbox.MapperConfig;
using Bookbox.Models;
using Bookbox.Repositories.Interface;
using Bookbox.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Bookbox.Repositories.Implementations
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        protected DbSet<Book> dbSet;
        public BookRepository(BookBoxDbContext dbContext) : base(dbContext)
        {
            this.dbSet = dbContext.Set<Book>();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorName(string name)
        {
            return await dbSet.Where(b => b.AuthorName.ToLower() == name.ToLower()).ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetBooksByTitle(string title)
        {
            return await dbSet.Where(b => b.Title.ToLower() == title.ToLower()).ToListAsync();
        }
        public async Task<Book> UpdateBook(Guid id, Book book)
        {
            var existingBook = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBook == null)
            {
                throw new ArgumentException("Book not found", nameof(book));

            }
            existingBook.Title = book.Title;
            existingBook.Price = book.Price;
            existingBook.ISBN = book.ISBN;
            return existingBook;
        }
    }
}















