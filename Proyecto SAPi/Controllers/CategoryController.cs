using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Service.Services.Contract;

namespace Proyecto_SAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _category;
        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _category.Get();

            return Ok(categories);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetByName(string name)
        {
            var cat = await _category.GetByName(name);

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);

        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _category.GetByKeys([id]);

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] Category category)
        //{
        //    if (category == null)
        //    {
        //        return BadRequest();
        //    }

        //    await _category.Create(category);

        //    return CreatedAtAction(nameof(GetByName), category.Name, category);
        //}
    }
}
