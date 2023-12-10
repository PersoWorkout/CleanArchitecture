using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoryService;

        public CategoriesController(ICategoriesService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.ListCategories());
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.CategoryById(id);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryValidator payload)
        {
            var result = await _categoryService.Create(payload);
            return result != null ? Created() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] int id, [FromBody] CategoryValidator payload)
        {
            var result = await _categoryService.Update(id, payload);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
