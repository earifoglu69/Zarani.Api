using Microsoft.AspNetCore.Mvc;
using Zarani.Application.Services.Product;
using Zarani.Domain.Dtos;

namespace Zarani.Api.Controllers
{
    public class ProductController : BaseController<ProductController>
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            var result = await _productService.AddProduct(productDto);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Parametre hatası");
            }
            var result = await _productService.GetProductById(id);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return NotFound(result.ErrorMessage);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
        {
            var result = await _productService.UpdateProduct(productDto);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result.Data)
            {
                return Ok(result);
            }
            return NotFound(result.ErrorMessage);
        }
    }
}
