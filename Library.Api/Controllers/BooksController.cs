using Library.Dtos;
using Library.Models;
using Library.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksAsync()
        {
            var book = await bookRepository.GetBooksAsync();
            return Ok(book);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookAsync(Guid id)
        {
            var existingBooks = await bookRepository.GetBookAsync(id);
            try
            {
                return Ok(existingBooks);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBookAsync(BookDto bookDto)
        {
            Book book = new()
            {
                Name = bookDto.Name,
                Cover = bookDto.Cover,
                Category = bookDto.Category,
                DatePublication = bookDto.DatePublication,
                AuthorId = bookDto.AuthorId
            };
            await bookRepository.CreateBookAsync(book);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBookAsync(Guid id, BookDto bookDto)
        {
            var existingBooks = await bookRepository.GetBookAsync(id);
            if (existingBooks is null)
            {
                return NotFound();
            }
            Book book = existingBooks with
            {
                Name = bookDto.Name,
                Cover = bookDto.Cover,
                Category = bookDto.Category,
                DatePublication = bookDto.DatePublication,
                AuthorId = bookDto.AuthorId
            };
            await bookRepository.UpdateBookAsync(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookAsync(Guid id)
        {
            var existingBooks = await bookRepository.GetBookAsync(id);
            if (existingBooks is null)
            {
                return NotFound();
            }
            await bookRepository.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
