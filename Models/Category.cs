using Bookbox.BaseClass;

namespace Bookbox.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
