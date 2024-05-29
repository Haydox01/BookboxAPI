using Bookbox.Data;
using Bookbox.MapperConfig;
using Bookbox.Models;
using Bookbox.Repositories.Implementations;
using Bookbox.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookbox.Repositories.Implementations
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        protected DbSet<Author> dbSet;
        public AuthorRepository(BookBoxDbContext dbContext) : base(dbContext)
        {
            this.dbSet = dbContext.Set<Author>();
        }
        public async Task<IEnumerable<Author>> GetAuthorsByName(string name)
        {
            return await dbSet.Where(b => b.Name.ToLower() == name.ToLower()).ToListAsync();
        }

        public async Task<Author> UpdateAuthor(Guid id, Author author)
        {
            var existingAuthor = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAuthor == null)
            {
                throw new ArgumentException("Author not found", nameof(author));

            }
            existingAuthor.Name = author.Name;
            existingAuthor.Nationality = author.Nationality;
            return existingAuthor;
        }

        
    }
}