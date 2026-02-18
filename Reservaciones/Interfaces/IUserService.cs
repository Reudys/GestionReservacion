using Reservaciones.Models;

namespace Reservaciones.Interfaces
{
    public interface IUserService
    {
        #region CRUD Methods
        Task<User> CreateUserAsync(User user);
        Task<IEnumerable<User>> GetUsersAsync();
        #endregion

        #region Custom Methods
        Task<User> GetUserByIdAsync(int id);
        #endregion
    }
}
