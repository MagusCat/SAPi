using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Contract;

namespace Proyecto_SAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;

        public UserController(IUserService user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _user.Get();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            var user = await _user.GetByKeys([id]);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("filter/")]
        public async Task<IActionResult> Filter(int? id_user, int? id_rol, string? username)
        {
            var users = await _user.Filter(id_user, id_rol, username);

            return Ok(users);
        }
    }
}