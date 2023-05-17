using Library.Domain.ViewModels;

namespace Library.Domain.Dtos
{
    public record AuthorsBooksDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Name { get; set; }
        public CoverType Cover { set; get; }
        public string Category { get; set; }
    }
}
