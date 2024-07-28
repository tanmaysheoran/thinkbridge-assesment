using Management.Contracts.Interface;
using Management.DBContext;
using Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly ApplicationDbContext _context;

        public UserRoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserRole> AssignUserRoleAsync(int userId, int roleId)
        {
            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId
            };

            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();

            return userRole;
        }

        public async Task<bool> UpdateUserRoleAsync(int userId, int roleId)
        {
            var userRole = await _context.UserRoles
                                         .FirstOrDefaultAsync(ur => ur.UserId == userId);

            if (userRole == null)
                return false;

            userRole.RoleId = roleId;
            _context.UserRoles.Update(userRole);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserRoleAsync(int userId, int roleId)
        {
            var userRole = await _context.UserRoles
                                         .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (userRole == null)
                return false;

            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
