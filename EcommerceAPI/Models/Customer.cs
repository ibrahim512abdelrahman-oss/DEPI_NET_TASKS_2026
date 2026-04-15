using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}