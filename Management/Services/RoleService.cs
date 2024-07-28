using Management.Contracts.Interface;
using Management.DBContext;
using Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Role> CreateRoleAsync(string roleName, string description)
        {
            var role = new Role
            {
                RoleName = roleName,
                Description = description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            var existingRole = await _context.Roles.FindAsync(role.RoleId);
            if (existingRole == null)
            {
                throw new Exception("Role not found");
            }

            existingRole.RoleName = role.RoleName;
            existingRole.Description = role.Description;
            existingRole.UpdatedAt = DateTime.UtcNow;

            _context.Roles.Update(existingRole);
            await _context.SaveChangesAsync();
            return existingRole;
        }

        public async Task<Role> DeleteRoleAsync(string roleName)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> GetRoleAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            return role;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
