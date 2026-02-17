using Reservaciones.Models;

namespace Reservaciones.Interfaces
{
    public interface IReservaService
    {
        Task<Reserva> CreateReservaAsync(Reserva reserva);
        Task<IEnumerable<Reserva>> GetReservasAsync();
        Task<Reserva> GetReservaByIdAsync(int id);
    }
}
