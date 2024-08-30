namespace Bookbox.DTOs.Response
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Nationality { get; set; }
    }
}
