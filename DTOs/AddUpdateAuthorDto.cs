using System.ComponentModel.DataAnnotations;

namespace Bookbox.Dto
{
    public class AddUpdateAuthorDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be a minimum of 3 characters")]
        [MaxLength(30, ErrorMessage = "Name has to be a maximum of 30 characters")]
        public string Name { get; set; }
        public string? Nationality { get; set; }
    }
}
