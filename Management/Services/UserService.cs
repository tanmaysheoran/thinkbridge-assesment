using Management.Contracts.Interface;
using Management.DBContext;
using Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Management.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context; 

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUserAsync(string username, string password, string firstname, string lastname, bool isAdmin)
        {
            var existingUser = await _context.Set<User>().SingleOrDefaultAsync(u => u.UserName == username);
            if (existingUser != null)
            {
                return false;  // Username already exists
            }

            var user = new User
            {
                UserName = username,
                Password = password,
                FirstName = firstname,
                LastName = lastname,
                IsAdmin = isAdmin,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Set<User>().Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var existingUser = await _context.Set<User>().FindAsync(user.UserId);
            if (existingUser == null)
            {
                return null;  // User not found
            }

            existingUser.UserName = user.UserName;
            existingUser.Password = user.Password;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.IsAdmin = user.IsAdmin;
            existingUser.IsActive = user.IsActive;
            existingUser.UpdatedAt = DateTime.UtcNow;

            _context.Set<User>().Update(existingUser);
            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            var existingUser = await _context.Set<User>().FindAsync(user.UserId);
            if (existingUser == null)
            {
                return false;  // User not found
            }

            _context.Set<User>().Remove(existingUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Set<User>().FindAsync(id);
        }

        public async Task<bool> UpdateUserStatusAsync(int id, bool isActive)
        {
            var user = await _context.Set<User>().FindAsync(id);
            if (user == null)
            {
                return false;  // User not found
            }

            user.IsActive = isActive;
            user.UpdatedAt = DateTime.UtcNow;

            _context.Set<User>().Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User?> LogInAsync(string username, string password)
        {
            var user = await _context.Set<User>().SingleOrDefaultAsync(u => u.UserName == username);
            if (user == null || user.Password != password)
            {
                return null;
            }
            return user;
        }

        public async Task<bool> LogOutAsync()
        {
            return await Task.FromResult(true);
        }
    }
}
