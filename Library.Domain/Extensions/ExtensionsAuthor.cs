using Library.Dtos;
using Library.Models;
namespace Library
{
    public static class ExtensionsAuthor
    {
        public static AuthorDto AsDtoAuthor(this Author author)
        {
            return new AuthorDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                Email = author.Email,
            };
        }
    }
}
