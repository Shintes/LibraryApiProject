using Library.Dtos;
using Library.Models;
using Library.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorsController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthorsAsync()
        {
            var getAuthors = await authorRepository.GetAuthorsAsync();
            return Ok(getAuthors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorAsync(Guid id)
        {
            var existingAuthor = await authorRepository.GetAuthorAsync(id);
            try
            {
                return Ok(existingAuthor);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthorAsync(AuthorDto authorDto)
        {
            Author author = new()
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
                Email = authorDto.Email,
            };
            await authorRepository.CreateAuthorAsync(author);
            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthorAsync(Guid id, AuthorDto authorDto)
        {
            var existingAuthor = await authorRepository.GetAuthorAsync(id);
            if (existingAuthor is null)
            {
                return NotFound();
            }
            Author author = existingAuthor with
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
                Email = authorDto.Email,
            };
            await authorRepository.UpdateAuthorAsync(author);
            return Ok(author);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthorAsync(Guid id)
        {
            var existingAuthor = await authorRepository.GetAuthorAsync(id);
            if (existingAuthor is null)
            {
                return NotFound();
            }
            await authorRepository.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}
