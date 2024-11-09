using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Contract;

namespace Proyecto_SAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unit;

        public UnitController(IUnitService unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var units = await _unit.Get();

            return Ok(units);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var unit = await _unit.GetByKeys([id]);

            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        [HttpGet("unit/{id_unit}")]
        public async Task<IActionResult> GetConvert(int id_unit) 
        {
            var units = await _unit.Get(id_unit);

            return Ok(units);
        }
    }
}
