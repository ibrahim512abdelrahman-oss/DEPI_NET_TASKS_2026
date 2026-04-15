using System.ComponentModel.DataAnnotations;

namespace HealthcareAPI.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        public DateTime DateOfBirth { get; set; }
        
        // Many-to-Many with Doctor (via Appointment)
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}