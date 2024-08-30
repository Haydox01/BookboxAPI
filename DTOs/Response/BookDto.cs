using Bookbox.Models;

namespace Bookbox.DTOs.Response
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public Guid AuthorId { get; set; }
        public string ISBN { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;



        public Category Category { get; set; }
        public Author Author { get; set; }

    }
}
