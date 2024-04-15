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

        public Task<Author> DeleteAuthorById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            return await dbContext.Authors.ToListAsync();
           
        }

        public Task<Author> GetAuthorsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Author>> GetAuthorsByName()
        {
            throw new NotImplementedException();
        }

        public Task<Author> UpdateAuthor(Guid id, Author author)
        {
            throw new NotImplementedException();
        }
    }
}
