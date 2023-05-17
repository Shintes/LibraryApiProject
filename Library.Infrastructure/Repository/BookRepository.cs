using Library.Infrastructure.Context;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{


    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext libraryDbContext;
        public BookRepository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public async Task CreateBookAsync(Book book)
        {
            book.Author = await libraryDbContext.Authors.FirstAsync(a => a.Id == book.AuthorId);
            await libraryDbContext.Books.AddAsync(book);
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var bookId = libraryDbContext.Books.FirstOrDefault(b => b.Id == id);
            libraryDbContext.Books.Remove(bookId);
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await libraryDbContext.Books.ToListAsync();
        }

        public Task<Book> GetBookAsync(Guid id)
        {
            return libraryDbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public Task<Author> GetAuthorAsync(Guid id)
        {
            return libraryDbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }


        public async Task UpdateBookAsync(Book book)
        {
            var dbBook = libraryDbContext.Books.FirstOrDefault(b => b.Id == book.Id);
            dbBook.Name = book.Name;
            dbBook.Category = book.Category;
            dbBook.Cover = book.Cover;
            dbBook.DatePublication = book.DatePublication;
            dbBook.AuthorId = book.AuthorId;
            await libraryDbContext.SaveChangesAsync();
        }
    }
}