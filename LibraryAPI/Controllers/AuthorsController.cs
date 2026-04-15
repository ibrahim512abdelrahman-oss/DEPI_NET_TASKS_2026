using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Dtos;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()
        {
            var authors = await _context.Authors
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    BirthDate = a.BirthDate
                })
                .ToListAsync();
            
            return Ok(authors);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetById(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            
            if (author == null)
                return NotFound();
            
            return Ok(new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                BirthDate = author.BirthDate
            });
        }
        
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Create(CreateAuthorDto createDto)
        {
            var author = new Author
            {
                Name = createDto.Name,
                BirthDate = createDto.BirthDate
            };
            
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById), new { id = author.Id },
                new AuthorDto
                {
                    Id = author.Id,
                    Name = author.Name,
                    BirthDate = author.BirthDate
                });
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAuthorDto updateDto)
        {
            var author = await _context.Authors.FindAsync(id);
            
            if (author == null)
                return NotFound();
            
            author.Name = updateDto.Name;
            author.BirthDate = updateDto.BirthDate;
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            
            if (author == null)
                return NotFound();
            
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}