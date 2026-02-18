using Reservaciones.Data;

namespace Reservaciones.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateOnly ReservDate { get; set; }
        public TimeOnly ReservTime { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public Secciones Seccion { get; set; }
    }
}
