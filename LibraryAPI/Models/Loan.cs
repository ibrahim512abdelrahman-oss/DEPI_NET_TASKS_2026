using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Loan
    {
        [Key, Column(Order = 0)]
        public int BookId { get; set; }
        
        [Key, Column(Order = 1)]
        public int BorrowerId { get; set; }
        
        [Required]
        public DateTime LoanDate { get; set; } = DateTime.Now;
        
        public DateTime? ReturnDate { get; set; }
        
        // Navigation Properties
        [ForeignKey("BookId")]
        public virtual Book? Book { get; set; }
        
        [ForeignKey("BorrowerId")]
        public virtual Borrower? Borrower { get; set; }
    }
}