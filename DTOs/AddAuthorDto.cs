using System.ComponentModel.DataAnnotations;

namespace Bookbox.DTOs
{
    public class AddAuthorDto
    {
        public string Name { get; set; }
        public string? Nationality { get; set; }
    }
}
