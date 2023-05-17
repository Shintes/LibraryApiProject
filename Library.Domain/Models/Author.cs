namespace Library.Models
{
    public record Author
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Book> BookList { get; set; }
    }
}