using System.ComponentModel.DataAnnotations;

namespace HealthcareAPI.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required, MaxLength(100)]
        public string Specialization { get; set; } = string.Empty;
        
        // Many-to-Many with Patient (via Appointment)
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
