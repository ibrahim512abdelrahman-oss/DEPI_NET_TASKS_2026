using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models
{
    public class OrderDetail
    {
        [Key, Column(Order = 0)]
        public int OrderId { get; set; }
        
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
    }
}