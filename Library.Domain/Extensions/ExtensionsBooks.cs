using Library.Dtos;
using Library.Models;

namespace Library
{
    public static class ExtensionsBooks
    {
        public static BookDto AsDtoBook(this Book book)
        {
            return new BookDto
            {
                Name = book.Name,
                Cover = book.Cover,
                Category = book.Category,
                DatePublication = book.DatePublication
            };
        }
    }
}
