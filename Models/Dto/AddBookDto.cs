using System.ComponentModel.DataAnnotations;

namespace Bookbox.Models.Dto
{
    public class AddBookDto
    {
        public string Title { get; set; }
        [Required]
        [Range(0, 1000000, ErrorMessage = "Book Price cannot exceed 1000000")]
        public Double Price { get; set; }
        public string AuthorName { get; set; }
        public Guid AuthorId { get; set; }
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public string? ISBN { get; set; }
      
    }
}
