using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        
        public int CustomerId { get; set; }
        
        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}