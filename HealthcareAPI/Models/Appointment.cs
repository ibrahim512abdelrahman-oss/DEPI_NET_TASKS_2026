using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareAPI.Models
{
    public class Appointment
    {
        [Key, Column(Order = 0)]
        public int PatientId { get; set; }
        
        [Key, Column(Order = 1)]
        public int DoctorId { get; set; }
        
        [Required]
        public DateTime AppointmentDate { get; set; }
        
        // Navigation Properties
        [ForeignKey("PatientId")]
        public virtual Patient? Patient { get; set; }
        
        [ForeignKey("DoctorId")]
        public virtual Doctor? Doctor { get; set; }
    }
}