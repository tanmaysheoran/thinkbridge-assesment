using Management.Models;

namespace Management.Contracts.Interface
{
    public interface IUserRoleService
    {
        Task<UserRole> AssignUserRoleAsync(int  userId, int roleId);
        Task<bool> UpdateUserRoleAsync(int userId, int roleId);
        Task<bool> DeleteUserRoleAsync(int userId, int roleId);
    }
}
