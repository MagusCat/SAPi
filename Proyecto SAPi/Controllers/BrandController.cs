using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Contract;

namespace Proyecto_SAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly  IBrandService _brand;

        public BrandController(IBrandService brand)
        {
            _brand = brand;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var brands = await _brand.Get();

            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var brand = await _brand.GetByKeys([id]);

            if (brand == null) 
            {
                return NotFound();
            }

            return Ok(brand);
        }
    }
}
