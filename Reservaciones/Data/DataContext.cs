using Microsoft.EntityFrameworkCore;
using Reservaciones.Models;

namespace Reservaciones.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Reserva> Reservaciones { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
