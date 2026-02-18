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

        #region CRUD Methods
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _service.CreateUserAsync(user);
            return Ok();
        }

        [HttpGet("Read")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.GetUsersAsync();
            return Ok(users);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id) return BadRequest();
            await _service.UpdateUserAsync(id, user);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _service.DeleteUserAsync(id);
            return Ok();
        }
        #endregion

        #region Custom Methods
        [HttpGet("Read/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        #endregion
    }
}
