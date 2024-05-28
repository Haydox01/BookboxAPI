using Bookbox.BaseClass;

namespace Bookbox.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public String ? Nationality  { get; set; }
    }
}
