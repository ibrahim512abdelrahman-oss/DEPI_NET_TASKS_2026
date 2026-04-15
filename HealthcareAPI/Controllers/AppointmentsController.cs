using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Data;
using HealthcareAPI.Dtos;
using HealthcareAPI.Models;

namespace HealthcareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAll()
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Select(a => new AppointmentDto
                {
                    PatientId = a.PatientId,
                    PatientName = a.Patient != null ? a.Patient.Name : null,
                    DoctorId = a.DoctorId,
                    DoctorName = a.Doctor != null ? a.Doctor.Name : null,
                    DoctorSpecialization = a.Doctor != null ? a.Doctor.Specialization : null,
                    AppointmentDate = a.AppointmentDate
                })
                .ToListAsync();
            
            return Ok(appointments);
        }
        
        [HttpGet("{patientId}/{doctorId}")]
        public async Task<ActionResult<AppointmentDto>> GetById(int patientId, int doctorId)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.PatientId == patientId && a.DoctorId == doctorId);
            
            if (appointment == null)
                return NotFound();
            
            return Ok(new AppointmentDto
            {
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.Name,
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.Doctor?.Name,
                DoctorSpecialization = appointment.Doctor?.Specialization,
                AppointmentDate = appointment.AppointmentDate
            });
        }
        
        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> Create(CreateAppointmentDto createDto)
        {
            var patient = await _context.Patients.FindAsync(createDto.PatientId);
            var doctor = await _context.Doctors.FindAsync(createDto.DoctorId);
            
            if (patient == null)
                return BadRequest("Patient not found");
            
            if (doctor == null)
                return BadRequest("Doctor not found");
            
            var appointment = new Appointment
            {
                PatientId = createDto.PatientId,
                DoctorId = createDto.DoctorId,
                AppointmentDate = createDto.AppointmentDate
            };
            
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById), new { patientId = appointment.PatientId, doctorId = appointment.DoctorId },
                new AppointmentDto
                {
                    PatientId = appointment.PatientId,
                    PatientName = patient.Name,
                    DoctorId = appointment.DoctorId,
                    DoctorName = doctor.Name,
                    DoctorSpecialization = doctor.Specialization,
                    AppointmentDate = appointment.AppointmentDate
                });
        }
        
        [HttpPut("{patientId}/{doctorId}")]
        public async Task<IActionResult> Update(int patientId, int doctorId, CreateAppointmentDto updateDto)
        {
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.PatientId == patientId && a.DoctorId == doctorId);
            
            if (appointment == null)
                return NotFound();
            
            appointment.AppointmentDate = updateDto.AppointmentDate;
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        
        [HttpDelete("{patientId}/{doctorId}")]
        public async Task<IActionResult> Delete(int patientId, int doctorId)
        {
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.PatientId == patientId && a.DoctorId == doctorId);
            
            if (appointment == null)
                return NotFound();
            
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}