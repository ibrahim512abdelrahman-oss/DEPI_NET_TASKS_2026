using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        public DateTime BirthDate { get; set; }
        
        // Navigation Property (One-to-Many)
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}