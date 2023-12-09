using CleanArchitecture.Data;
using CleanArchitecture.Models;
using CleanArchitecture.Validators.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CatalogDbContext _db;
        public ProductsController(CatalogDbContext db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _db.Products.ToListAsync());
        }

        [HttpPost]  
        public async Task<IActionResult> Create([FromBody] CreateProductValidator payload)
        {
            if (!await _db.Categories.AnyAsync((c) => c.Id == payload.idCategory))
            {
                return BadRequest();
            }

            Products product = new() {
                Name= payload.name, 
                Description=payload.description, 
                Price=payload.price,
                CategoryId=payload.idCategory
            };

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return Created();
        }

        [HttpGet("id")]
        public async Task<IActionResult> Show([FromQuery]int id)
        {
            return Ok(await _db.Products.Where((p) => p.Id == id).FirstOrDefaultAsync());
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] CreateProductValidator payload)
        {
            Products? product = await _db.Products.Where((p) => p.Id == id).FirstOrDefaultAsync();
            if(product == null)
            {
                return BadRequest();
            }

            if(!await _db.Categories.AnyAsync((c) => c.Id == payload.idCategory))
            {
                return BadRequest();
            }

            product.Name = payload.name;
            product.Description = payload.description;
            product.Price = payload.price;
            product.CategoryId = payload.idCategory;

            await _db.SaveChangesAsync();

            return Ok(product);
        }
    }
}
