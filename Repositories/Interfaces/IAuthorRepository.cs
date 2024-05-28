using Bookbox.Models;

namespace Bookbox.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsByName(string name);
        Task<Author> UpdateAuthor(Guid id, Author author);
    }
}
