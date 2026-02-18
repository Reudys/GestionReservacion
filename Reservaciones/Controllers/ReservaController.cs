using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservaciones.Interfaces;
using Reservaciones.Models;

namespace Reservaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _service;

        public ReservaController(IReservaService reservaService) { _service = reservaService; }

        #region CRUD Methods
        [HttpPost("Create")]
        public async Task<IActionResult> CreateReserva(Reserva reserva)
        {
            await _service.CreateReservaAsync(reserva);
            return Ok();
        }

        [HttpGet("Read")]
        public async Task<IActionResult> GetReservas()
        {
            var reservas = await _service.GetReservasAsync();
            return Ok(reservas);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateReserva(int id, Reserva reserva)
        {
            var existingReserva = await _service.UpdateReservaAsync(id, reserva);
            if (existingReserva == null) return NotFound();
            return Ok(existingReserva);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var deleted = await _service.DeleteReservaAsync(id);
            if (!deleted) return NotFound();
            return Ok();
        }
        #endregion

        #region Custom Methods
        [HttpGet("Read/{id}")]
        public async Task<IActionResult> GetReservaById(int id)
        {
            var reserva = await _service.GetReservaByIdAsync(id);
            if (reserva == null) return NotFound();
            return Ok(reserva);
        }
        #endregion
    }
}
