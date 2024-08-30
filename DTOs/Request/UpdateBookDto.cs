namespace Bookbox.DTOs.Request
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string? ISBN { get; set; }
    }
}
