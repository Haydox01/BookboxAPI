using Bookbox.Models;

namespace Bookbox.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthors();
        Task<List<Author>> GetAuthorsByName();
        Task<Author> GetAuthorsById(Guid id);

        Task<Author> UpdateAuthor(Guid id, Author author);
        Task <Author> DeleteAuthorById(Guid id);
        Task<Author> CreateAuthor(Author author);
    }
}
