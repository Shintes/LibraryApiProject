using Library.Models;

namespace Library.Repository
{
    public interface IBookRepository
    {
        Task<Book> GetBookAsync(Guid Id);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Guid Id);
    }
}
