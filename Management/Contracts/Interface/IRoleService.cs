using Management.Models;

namespace Management.Contracts.Interface
{
    public interface IRoleService
    {
        Task<Role> CreateRoleAsync(string roleName, string description);
        Task<Role> UpdateRoleAsync(Role role);
        Task<Role> DeleteRoleAsync(string roleName);
        Task<Role> GetRoleAsync(int id);
        Task<List<Role>> GetAllRolesAsync();
    }
}
