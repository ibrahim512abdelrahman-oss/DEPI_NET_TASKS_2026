using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Data;
using HealthcareAPI.Dtos;
using HealthcareAPI.Models;

namespace HealthcareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public DoctorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAll()
        {
            var doctors = await _context.Doctors
                .Select(d => new DoctorDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Specialization = d.Specialization
                })
                .ToListAsync();
            
            return Ok(doctors);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetById(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            
            if (doctor == null)
                return NotFound();
            
            return Ok(new DoctorDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Specialization = doctor.Specialization
            });
        }
        
        [HttpPost]
        public async Task<ActionResult<DoctorDto>> Create(CreateDoctorDto createDto)
        {
            var doctor = new Doctor
            {
                Name = createDto.Name,
                Specialization = createDto.Specialization
            };
            
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById), new { id = doctor.Id },
                new DoctorDto
                {
                    Id = doctor.Id,
                    Name = doctor.Name,
                    Specialization = doctor.Specialization
                });
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDoctorDto updateDto)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            
            if (doctor == null)
                return NotFound();
            
            doctor.Name = updateDto.Name;
            doctor.Specialization = updateDto.Specialization;
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            
            if (doctor == null)
                return NotFound();
            
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}