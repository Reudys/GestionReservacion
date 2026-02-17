using Microsoft.EntityFrameworkCore;
using Reservaciones.Data;
using Reservaciones.Interfaces;
using Reservaciones.Models;

namespace Reservaciones.Services
{
    public class ReservaService : IReservaService
    {
        private readonly DataContext _context;
        
        public ReservaService(DataContext context)  { _context = context; }

        public async Task<Reserva> CreateReservaAsync(Reserva reserva)
        {
            _context.Reservaciones.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<IEnumerable<Reserva>> GetReservasAsync()
        {
            return await _context.Reservaciones.ToListAsync();
        }

        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            return await _context.Reservaciones.FindAsync(id);
        }
    }
}
