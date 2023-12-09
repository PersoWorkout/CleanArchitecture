using CleanArchitecture.Data;
using CleanArchitecture.Models;
using CleanArchitecture.Validators.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CatalogDbContext _db;
        public CategoriesController(CatalogDbContext db) {
            _db = db;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _db.Categories.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryValidator payload)
        {
            Categories category = new()
            {
                Name = payload.name
            };

            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return Created();
        }

        [HttpGet("id")]
        public async Task<IActionResult> Show([FromQuery] int id)
        {
            return Ok(await _db.Categories.Where((c) => c.Id == id).FirstOrDefaultAsync());
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] CreateCategoryValidator payload)
        {
            Categories? category = await _db.Categories.Where((c) => c.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return BadRequest();
            }

            category.Name = payload.name;

            await _db.SaveChangesAsync();

            return Ok(category);
        }
    }
}
