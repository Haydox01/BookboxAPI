namespace Bookbox.Models.Dto
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public Double Price { get; set; }
        public string AuthorName { get; set; }
        public Guid AuthorId { get; set; }
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public string? ISBN { get; set; }
      
    }
}
