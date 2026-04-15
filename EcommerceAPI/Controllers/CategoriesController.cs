using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceAPI.Data;
using EcommerceAPI.Dtos;
using EcommerceAPI.Models;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
            
            return Ok(categories);
        }
        
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            
            if (category == null)
                return NotFound();
            
            return Ok(new CategoryDto { Id = category.Id, Name = category.Name });
        }
        
        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto createDto)
        {
            var category = new Category
            {
                Name = createDto.Name
            };
            
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, 
                new CategoryDto { Id = category.Id, Name = category.Name });
        }
        
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryDto updateDto)
        {
            var category = await _context.Categories.FindAsync(id);
            
            if (category == null)
                return NotFound();
            
            category.Name = updateDto.Name;
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        
        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            
            if (category == null)
                return NotFound();
            
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}