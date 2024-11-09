using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Contract;

namespace Proyecto_SAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;

        public ProductController(IProductService product) {
            _product = product;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _product.Get();

            return Ok(products);
        }

        [HttpGet("filter/")]
        public async Task<IActionResult> Filter(int? id_product, int? id_category, int? id_brand, string? name)
        {
            var products = await _product.Filter(id_product, id_brand, id_category, name);

            return Ok(products);
        }

        [HttpGet("name/")]
        public async Task<IActionResult> GetByName(string name)
        {
            var product = await _product.GetByName(name);

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var product = await _product.GetByKeys([id]);

            if (product == null) 
            {
                return NotFound();
            }

            return Ok(product);
        }


    }
}
