using Reservaciones.Models;

namespace Reservaciones.Interfaces
{
    public interface IUserService
    {
        #region CRUD Methods
        Task<User> CreateUserAsync(User user);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);

        #endregion

        #region Custom Methods
        Task<User> GetUserByIdAsync(int id);
        #endregion
    }
}
