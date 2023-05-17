using Library.Models;

namespace Library.Infrastructure
{
    public interface IReportsRepository
    {
        Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId);
        Task<int> GetAverage();
    }
}
