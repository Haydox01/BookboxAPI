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
            Authors = new AuthorRepository(dbContext);
            Books = new BookRepository(dbContext);
        }
        public IBookRepository Books { get; private set; }
        public IAuthorRepository Authors { get; private set; }

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
