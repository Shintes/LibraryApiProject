using Library.Infrastructure.Context;
using Library.Infrastructure;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repository
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly LibraryDbContext libraryDbContext;
        public ReportsRepository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId)
        {
            var authorid = await libraryDbContext.Books.Where(b => b.AuthorId == authorId).Include(b => b.Author).ToListAsync();
            return authorid;
        }
            
        public Task<int> GetAverage()
        {
            var numberOfBooks = libraryDbContext.Books.Count();
            var numberOfAuthors = libraryDbContext.Authors.Count();
            return Task.FromResult(numberOfBooks/numberOfAuthors);
        }
    }
}
