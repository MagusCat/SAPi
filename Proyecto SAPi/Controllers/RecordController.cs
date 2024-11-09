using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Contract;

namespace Proyecto_SAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordService _record;

        public RecordController(IRecordService record)
        {
            _record = record;
        }

        [HttpGet("Entries")]
        public async Task<IActionResult> Entries()
        {
            var entries = await _record.GetEntries();

            return Ok(entries);
        }

        [HttpGet("Exits")]
        public async Task<IActionResult> Exits()
        {
            var exities = await _record.GetExits();

            return Ok(exities);
        }
    }
}
