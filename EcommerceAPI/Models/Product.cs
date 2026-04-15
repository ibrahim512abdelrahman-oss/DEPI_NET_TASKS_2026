using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}