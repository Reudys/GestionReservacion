using Reservaciones.Data;
using Reservaciones.Interfaces;
using Reservaciones.Models;
using Microsoft.EntityFrameworkCore;

namespace Reservaciones.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context) { _context = context; }

        #region CRUD Methods
        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        #endregion

        #region Custom Methods
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        #endregion
    }
}