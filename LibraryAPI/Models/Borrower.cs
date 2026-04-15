using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Borrower
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        public DateTime MembershipDate { get; set; } = DateTime.Now;
        
        // Many-to-Many with Book (via Loan)
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}