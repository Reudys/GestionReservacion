using Reservaciones.Models;

namespace Reservaciones.Interfaces
{
    public interface IReservaService
    {
        #region CRUD Methods
        Task<Reserva> CreateReservaAsync(Reserva reserva);
        Task<IEnumerable<Reserva>> GetReservasAsync();
        Task<Reserva> UpdateReservaAsync(int id, Reserva reserva);
        Task<bool> DeleteReservaAsync(int id);
        #endregion

        #region Custom Methods
        Task<Reserva> GetReservaByIdAsync(int id);
        #endregion
    }
}
