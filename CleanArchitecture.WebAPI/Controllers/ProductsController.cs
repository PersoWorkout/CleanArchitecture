using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productService.ProductsList());
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productService.ProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductValidator payload)
        {
            var result = await _productService.Create(payload);
            return result != null ? Created() : BadRequest();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put([FromQuery] int id, [FromBody] UpdateProductValidator payload)
        {
            var result = await _productService.Update(id, payload);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
