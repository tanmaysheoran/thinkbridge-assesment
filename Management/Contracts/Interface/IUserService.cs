using Management.Models;

namespace Management.Contracts.Interface
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(string username, string password, string firstname, string lastname, bool isAdmin);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(User user);
        Task<User> GetUserAsync(int id);
        Task<bool> UpdateUserStatusAsync(int id, bool IsActive);
        Task<User?> LogInAsync(string username, string password);
        Task<bool> LogOutAsync();
    }
}
