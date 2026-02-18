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

        #region CRUD Methods
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
        public async Task<Reserva> UpdateReservaAsync(int id, Reserva reserva)
        {
            var existing = await _context.Reservaciones.FindAsync(id);
            if (existing == null) return null;
            existing.Name = reserva.Name;
            existing.ReservDate = reserva.ReservDate;
            existing.ReservTime = reserva.ReservTime;
            existing.Amount = reserva.Amount;
            existing.Seccion = reserva.Seccion;
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteReservaAsync(int id)
        {
            var existing = await _context.Reservaciones.FindAsync(id);
            if (existing == null) return false;
            _context.Reservaciones.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion

        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            return await _context.Reservaciones.FindAsync(id);
        }
    }
}
