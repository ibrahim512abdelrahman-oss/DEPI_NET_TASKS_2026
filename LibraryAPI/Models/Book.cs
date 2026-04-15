using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required, MaxLength(20)]
        public string ISBN { get; set; } = string.Empty;
        
        // Foreign Key
        public int AuthorId { get; set; }
        
        // Navigation Properties
        [ForeignKey("AuthorId")]
        public virtual Author? Author { get; set; }
        
        // Many-to-Many with Borrower (via Loan)
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}