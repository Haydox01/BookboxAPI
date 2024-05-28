using Bookbox.Data;
using Bookbox.Models;
using Bookbox.Repositories.Interface;
using Bookbox.Repositories.Interfaces;

namespace Bookbox.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BookBoxDbContext dbContext;

        public UnitOfWork(BookBoxDbContext dbContext)
        {
            this.dbContext = dbContext;
            Author = new AuthorRepository(dbContext);
            Book = new BookRepository(dbContext);
        }
        public IBookRepository Book { get; private set; }
        public IAuthorRepository Author { get; private set; }

        public async Task CompleteAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

    }
}
