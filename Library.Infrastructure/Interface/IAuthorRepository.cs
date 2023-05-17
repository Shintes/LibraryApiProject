using Library.Models;

namespace Library.Repository
{
    public interface IAuthorRepository
    {
        Task<Author> GetAuthorAsync(Guid Id);
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task CreateAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(Guid Id);
    }
}