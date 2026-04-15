using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Data;
using HealthcareAPI.Dtos;
using HealthcareAPI.Models;

namespace HealthcareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll()
        {
            var patients = await _context.Patients
                .Select(p => new PatientDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    DateOfBirth = p.DateOfBirth
                })
                .ToListAsync();
            
            return Ok(patients);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetById(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            
            if (patient == null)
                return NotFound();
            
            return Ok(new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth
            });
        }
        
        [HttpPost]
        public async Task<ActionResult<PatientDto>> Create(CreatePatientDto createDto)
        {
            var patient = new Patient
            {
                Name = createDto.Name,
                DateOfBirth = createDto.DateOfBirth
            };
            
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById), new { id = patient.Id },
                new PatientDto
                {
                    Id = patient.Id,
                    Name = patient.Name,
                    DateOfBirth = patient.DateOfBirth
                });
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePatientDto updateDto)
        {
            var patient = await _context.Patients.FindAsync(id);
            
            if (patient == null)
                return NotFound();
            
            patient.Name = updateDto.Name;
            patient.DateOfBirth = updateDto.DateOfBirth;
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            
            if (patient == null)
                return NotFound();
            
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}