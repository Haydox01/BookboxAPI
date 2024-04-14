namespace Bookbox.Models.Dto
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public Double Price { get; set; }
        public string? ISBN { get; set; }
    }
}
