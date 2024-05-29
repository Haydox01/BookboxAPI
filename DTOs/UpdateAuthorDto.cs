using System.ComponentModel.DataAnnotations;

namespace Bookbox.Dto
{
    public class UpdateAuthorDto
    {
        public string Name { get; set; }
        public string? Nationality { get; set; }
    }
}
