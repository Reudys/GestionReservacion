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

        [HttpPost]
        public async Task<IActionResult> CreateReserva(Reserva reserva)
        {
            await _service.CreateReservaAsync(reserva);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetReservas()
        {
            var reservas = await _service.GetReservasAsync();
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservaById(int id)
        {
            var reserva = await _service.GetReservaByIdAsync(id);
            if (reserva == null) return NotFound();
            return Ok(reserva);
        }
    }
}
