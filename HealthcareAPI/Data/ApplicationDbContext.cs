using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Models;

namespace HealthcareAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure Many-to-Many relationship
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.PatientId, a.DoctorId });
        }
    }
}