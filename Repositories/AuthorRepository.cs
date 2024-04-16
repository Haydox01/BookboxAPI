using Bookbox.Data;
using Bookbox.MapperConfig;
using Bookbox.Models;
using Bookbox.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookbox.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookBoxDbContext dbContext;
        private readonly MappingProfiles mapping;

        public AuthorRepository(BookBoxDbContext dbContext, MappingProfiles mapping) 
        {
            this.dbContext = dbContext;
            this.mapping = mapping;
        }   
        public async Task<Author> CreateAuthor(Author author)
        {
            await dbContext.Authors.AddAsync(author);
            await dbContext.SaveChangesAsync();
            return author;
            
        }

        public async Task<Author> DeleteAuthorById(Guid id)
        {
            var Author= dbContext.Authors.FirstOrDefault(x => x.Id==id);
            if (Author==null)
            {
                return null;
            }
            dbContext.Authors.Remove(Author);
            await dbContext.SaveChangesAsync();
            return Author;
          


        }

        public async Task<List<Author>> GetAllAuthors()
        {
            return await dbContext.Authors.ToListAsync();
           
        }

        public Task<Author> GetAuthorsById(Guid id)
        {

            return dbContext.Authors.FirstOrDefaultAsync(author => author.Id == id);
        }

        public async Task<List<Author>> GetAuthorsByName(string name)
        {
         
          return await dbContext.Authors.Where(x=> x.Name.ToLower() == name.ToLower()).ToListAsync();
        }

        public async Task<Author> UpdateAuthor(Guid id, Author author)
        {
           var Author = dbContext.Authors.FirstOrDefault(author => author.Id == id);
            if (Author == null)
            {
                throw new ArgumentException("Book not found", nameof(author));
            }
            Author.Name = author.Name;
            Author.Nationality = author.Nationality;
            await dbContext.SaveChangesAsync();
            return Author;
        }
    }
}
