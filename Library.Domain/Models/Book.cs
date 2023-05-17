using Library.Domain.ViewModels;

namespace Library.Models
{
    public record Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CoverType Cover { get; set; }
        public CategoryType Category { get; set; }
        public DateTimeOffset DatePublication { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

