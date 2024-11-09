using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Service.Services.Contract;

namespace Proyecto_SAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _role;

        public RoleController(IRoleService role)
        {
            _role = role;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var roles = await _role.Get();

            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var role = await _role.GetByKeys([id]);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }
    }
}
