using Bookbox.BaseClass;

namespace Bookbox.Models
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }    
        public string ShippingAddress { get; set; }
        public Guid BookId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public double TotalAmount { get; set; }

        //nav Properties

        public Customer Customer { get; set; }
        public Book Book { get; set; }
    }
}
