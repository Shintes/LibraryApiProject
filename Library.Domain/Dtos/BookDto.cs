using Library.Domain.ViewModels;

namespace Library.Dtos
{
    public record BookDto
    {
        public string Name { get; set; }
        public CoverType Cover { get; set; }
        public CategoryType Category { get; set; }
        public DateTimeOffset DatePublication { get; set; }
        public Guid AuthorId { get; set; }
    }
}
