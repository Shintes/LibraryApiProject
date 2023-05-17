using Library.Infrastructure.Context;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext libraryDbContext;
        public AuthorRepository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await libraryDbContext.Authors.ToListAsync();
        }

        public Task<Author> GetAuthorAsync(Guid id)
        {
           return libraryDbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task CreateAuthorAsync(Author author)
        {
            await libraryDbContext.Authors.AddAsync(author);
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            var dbAuthor = libraryDbContext.Authors.FirstOrDefault(a => a.Id == author.Id);
            dbAuthor.Email = author.Email;
            dbAuthor.FirstName = author.FirstName;
            dbAuthor.LastName = author.LastName;
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(Guid id)
        {
            var authorId = libraryDbContext.Authors.FirstOrDefault(a => a.Id == id);
            libraryDbContext.Authors.Remove(authorId);
            await libraryDbContext.SaveChangesAsync();
        }
    }
}
