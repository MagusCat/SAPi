using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Contract;

namespace Proyecto_SAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventory;

        public InventoryController(IInventoryService inventory)
        {
            _inventory = inventory;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var inventories = await _inventory.Get();

            return Ok(inventories);
        }

        [HttpGet("{id_product}")]
        public async Task<IActionResult> Get(int id_product)
        {
            var inv = await _inventory.Get(id_product);

            if (inv == null)
            {
                return NotFound();
            }

            return Ok(inv);
        }

        [HttpGet("stock/{id_product}")]
        public async Task<IActionResult> Stock(int id_product)
        {
            var stock = await _inventory.Stock(id_product);

            return Ok(stock);
        }
    }
}
