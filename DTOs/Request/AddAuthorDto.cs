using System.ComponentModel.DataAnnotations;

namespace Bookbox.DTOs.Request
{
    public class AddAuthorDto
    {
        public string Name { get; set; }
        public string? Nationality { get; set; }
    }
}
