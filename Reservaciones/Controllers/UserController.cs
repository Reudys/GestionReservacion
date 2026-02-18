using Microsoft.AspNetCore.Mvc;
using Reservaciones.Interfaces;
using Reservaciones.Models;

namespace Reservaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService userService) { _service = userService; }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _service.CreateUserAsync(user);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("Read/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
